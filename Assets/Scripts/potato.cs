using UnityEngine;
using System.Collections;

public class potato : MonoBehaviour {

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    public bool hasSecondJumped;
    public bool hasHitFloor;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponentInChildren<BoxCollider2D>();
        hasSecondJumped = false;
        hasHitFloor = true;

        rb.AddForce(new Vector2(50.0f, 0.0f));
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (!hasSecondJumped && Input.GetKeyDown("up"))
        {
            //second jump
            rb.AddForce(new Vector2(-250.0f,200.0f));
            hasSecondJumped = true;
        }

        if (hasHitFloor && Input.GetKeyDown("up"))
        {
            //first jump
            rb.AddForce(new Vector2(0.0f, 200.0f));
            hasSecondJumped = false;
            hasHitFloor = false;
        }


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
            rb.AddForce(new Vector2(-60.0f, 0.0f));
        }

    }
}
