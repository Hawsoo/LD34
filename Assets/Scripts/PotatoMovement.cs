using UnityEngine;
using System.Collections;

public class PotatoMovement : MonoBehaviour {

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    public bool hasSecondJumped;
    public bool hasHitFloor;
    public bool CanSecondJump;

    public float Acceleration = 1f;

    public float ConstantMvtSpeed = 0.13f;

    public float JumpSpeed = 1;
    public float SecondJumpSpeed = 2;

    private bool UpPressedPrev = false;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponentInChildren<BoxCollider2D>();
        hasSecondJumped = false;
        hasHitFloor = true;
        CanSecondJump = false;
	}
	
	// Update is called once per frame
	void FixedUpdate() {

        if (transform.position.y < -20)
        {
            Application.LoadLevel("deathMenu");
        }

        Vector2 velo = rb.velocity;

        //if (rb.velocity.x < 5.0f && (!CanSecondJump || (CanSecondJump && hasSecondJumped)))
        //{
        //    velo.x += Acceleration;
        //}

        if (hasHitFloor && Input.GetKey("up") && !UpPressedPrev)
        {
            // first jump
            velo = new Vector2(velo.x, JumpSpeed);
            hasSecondJumped = false;
            hasHitFloor = false;
            CanSecondJump = true;
        }
        else if (!hasSecondJumped && CanSecondJump && Input.GetKey("up") && !UpPressedPrev)
        {
            // second jump
            velo = new Vector2(velo.x, SecondJumpSpeed);
            hasSecondJumped = true;
            CanSecondJump = false;
        }

        if (CanSecondJump)
        { velo.x = -0.1f; }

        rb.velocity = velo;


        transform.up = Vector3.up;

        // Undo Trigger vars
        hasHitFloor = false;
        UpPressedPrev = Input.GetKey("up");
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        //if collision is a floor
        //if (collision.transform.position.y + collision.collider.bounds.size.y / 2.0f < transform.position.y - bc.bounds.size.y / 2.0f)
        if (collision.gameObject.tag != "wall")
        {
            hasHitFloor = true;
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        //if collision is a floor
        //if (collision.transform.position.y + collision.collider.bounds.size.y / 2.0f < transform.position.y - bc.bounds.size.y / 2.0f)
        //void FloorCollision()
        if (collision.gameObject.tag == "Floor")
        {
            hasHitFloor = true;
            hasSecondJumped = false;
            UpPressedPrev = false;
        }

        //its a wall
        //if (collision.transform.position.x - collision.collider.bounds.size.x / 2.0f > transform.position.x + bc.bounds.size.x / 2.0f)
        //void WallCollision()
        if (collision.gameObject.tag == "Wall")
        {
            //CanSecondJump = true;
            Vector2 velo = rb.velocity;
            velo.x = 0;
            rb.velocity = velo;
        }
    }

}
