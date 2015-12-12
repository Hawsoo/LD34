using UnityEngine;
using System.Collections;

public class PotatoMovement : MonoBehaviour {

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    public bool hasSecondJumped;
    public bool hasHitFloor;

    public float JumpSpeed = 10;
    public float SecondJumpKickoffSpeed = 12;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponentInChildren<BoxCollider2D>();
        hasSecondJumped = false;
        hasHitFloor = true;
	}
	
	// Update is called once per frame
	void FixedUpdate() {

        Vector2 velo = rb.velocity;

        if (!hasSecondJumped && Input.GetKeyDown("up"))
        {
            //second jump
            velo = new Vector2(-SecondJumpKickoffSpeed, JumpSpeed);
            hasSecondJumped = true;
        }

        if (hasHitFloor && Input.GetKeyDown("up"))
        {
            //first jump
            velo = new Vector2(velo.x, JumpSpeed);
            hasSecondJumped = false;
            hasHitFloor = false;
        }

        rb.velocity = velo;


        transform.up = Vector3.up;
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
        if(collision.gameObject.tag != "wall")
        {
            hasHitFloor = true;
        }

        //its a wall
        //if (collision.transform.position.x - collision.collider.bounds.size.x / 2.0f > transform.position.x + bc.bounds.size.x / 2.0f)
        if (collision.gameObject.tag == "wall")
        {
            Vector2 velo = rb.velocity;
            velo.x = 0;
            rb.velocity = velo;
        }

    }
}
