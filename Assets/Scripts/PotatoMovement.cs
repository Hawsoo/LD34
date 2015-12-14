using UnityEngine;
using System.Collections;

public class PotatoMovement : MonoBehaviour {

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    public bool hasHitFloor;
    public int MaxJumps = 2;
    private int JumpsMade = 0;

    private bool HitWall;

    public float Acceleration = 1f;

    public float JumpLiftOff = 1;
    public float ConstantMvtSpeed = 10f;

    public float JumpSpeed = 10;

    private bool UpPressedPrev = false;
    private bool RightPressedPrev = false;

    public bool IsCharging = false;
	public float ChargeTime;
	private float ChargeTimeWaited;

    public AudioClip Jump;
    public AudioClip Charge;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponentInChildren<BoxCollider2D>();
        hasHitFloor = true;
        HitWall = false;
	}
	
	// Update is called once per frame
	void FixedUpdate() {

        Vector2 velo = rb.velocity;

        if (rb.velocity.x < 5.0f/* && (!CanSecondJump || (CanSecondJump && hasSecondJumped))*/)
        {
            velo.x += Acceleration;
        }
        else
        {
            velo.x = 5.0f;
        }

        if (((hasHitFloor/* && JumpsMade == 0*/) || (JumpsMade < MaxJumps)) && Input.GetKey("up") && !UpPressedPrev)
        {
            if (!hasHitFloor && JumpsMade == 0) { JumpsMade++; }
            transform.position = new Vector3(transform.position.x, transform.position.y + JumpLiftOff, transform.position.z);
            
            // first jump
            velo = new Vector2(velo.x, JumpSpeed);
            //hasSecondJumped = false;
            hasHitFloor = false;

            AudioUtils.Audio.PlayOneShot(Jump);
            
            JumpsMade++;
        }
        //else if (!hasSecondJumped && CanSecondJump && Input.GetKey("up") && !UpPressedPrev)
        //{
        //    transform.position = new Vector3(transform.position.x - JumpLiftOff, transform.position.y, transform.position.z);

        //    // second jump
        //    velo = new Vector2(-SecondJumpKickoffSpeed, JumpSpeed);
        //    hasSecondJumped = true;
        //    CanSecondJump = false;
        //}

        // Do charge
        if (hasHitFloor && GetComponent<PotatoGrow>().IsLarge && Input.GetKey("right") && !RightPressedPrev && !IsCharging)
        {
			IsCharging = true;
			ChargeTimeWaited = 0;
            AudioUtils.Audio.PlayOneShot(Charge);

            // Override Animation
            GetComponent<PotatoMechanim>().OverrideMechanim = true;
            GetComponent<PotatoMechanim>().LargePotato.SetBool("OnGround", false);

            // Go twice as fast
            velo.x = 10;
        }
        // Keep doing charge until sound ends
        else if (GetComponent<PotatoGrow>().IsLarge && IsCharging)
        {
			ChargeTimeWaited += Time.deltaTime;
			if (ChargeTime <= ChargeTimeWaited)
			{
				IsCharging = false;
			}

            // Override Animation
            GetComponent<PotatoMechanim>().OverrideMechanim = true;
            GetComponent<PotatoMechanim>().LargePotato.SetBool("OnGround", false);

            // Go twice as fast
            velo.x = 10;
        }
        //else if (GetComponent<PotatoGrow>().IsLarge && !AudioUtils.Audio.isPlaying && IsCharging)
        //{
        //    // Undo
        //    IsCharging = false;
        //}

        if (HitWall)
        { velo.x = 0; }

        rb.velocity = velo;
		Debug.Log (velo.x);;

        transform.up = Vector3.up;

        // Undo Trigger vars
        hasHitFloor = false;
        //CanSecondJump = false;
        HitWall = false;
        UpPressedPrev = Input.GetKey("up");
        RightPressedPrev = Input.GetKey("right");
	}
    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    //if collision is a floor
    //    //if (collision.transform.position.y + collision.collider.bounds.size.y / 2.0f < transform.position.y - bc.bounds.size.y / 2.0f)
    //    if (collision.gameObject.tag != "wall")
    //    {
    //        hasHitFloor = true;
    //    }
    //}
    //void OnCollisionStay2D(Collision2D collision)
    //{
    //    //if collision is a floor
    //    //if (collision.transform.position.y + collision.collider.bounds.size.y / 2.0f < transform.position.y - bc.bounds.size.y / 2.0f)
    //    if (collision.gameObject.tag != "Collider")

    void FloorCollision()
    {
        hasHitFloor = true;
        JumpsMade = 0;
        //hasSecondJumped = false;
    }
        //its a wall
        //if (collision.transform.position.x - collision.collider.bounds.size.x / 2.0f > transform.position.x + bc.bounds.size.x / 2.0f)
        //if (collision.gameObject.tag == "wall")
    //}

    void WallCollision()
    {
        //CanSecondJump = true;
        HitWall = true;
        Vector2 velo = rb.velocity;
        velo.x = 0;
        rb.velocity = velo;
    }
}
