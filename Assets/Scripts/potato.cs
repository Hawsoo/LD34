using UnityEngine;
using System.Collections;

public class potato : MonoBehaviour {

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    //private Renderer rend;
    public bool hasSecondJumped;
    public bool hasHitFloor;
    public bool touchingWall;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponentInChildren<BoxCollider2D>();
        //rend = GetComponent<Renderer>();
        hasSecondJumped = false;
        hasHitFloor = true;
        touchingWall = false;

        rb.AddForce(new Vector2(50.0f, 0.0f));
	}
	
	// Update is called once per frame
	void Update () {

        if(rb.velocity.x<5.0f && !touchingWall)
        {
            rb.AddForce(new Vector2(50.0f, 0.0f));
        }


        if (!hasSecondJumped && Input.GetKeyDown("up"))
        {
            //second jump
            rb.AddForce(new Vector2(-250.0f,200.0f));
            hasSecondJumped = true;
        }

        if (hasHitFloor && Input.GetKeyDown("up"))
        {
            //first jump
            rb.AddForce(new Vector2(0.0f, 150.0f));
            hasSecondJumped = false;
            hasHitFloor = false;
        }


        transform.up = Vector3.up;
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        //if collision is a floor
        if (collision.transform.position.y + collision.collider.bounds.size.y / 2.0f < transform.position.y - bc.bounds.size.y / 2.0f)
        {
            hasHitFloor = true;
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        //its a wall
        if (collision.transform.position.x - collision.collider.bounds.size.x / 2.0f > transform.position.x + bc.bounds.size.x / 2.0f)
        {
            touchingWall = true;
        }
        else { touchingWall = false; }
    }
}
