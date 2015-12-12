using UnityEngine;
using System.Collections;

public class potato : MonoBehaviour {

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private Renderer rend;
    public bool hasSecondJumped;
    public bool hasHitFloor;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        rend = GetComponent<Renderer>();
        hasSecondJumped = false;
        hasHitFloor = true;
	}
	
	// Update is called once per frame
	void Update () {
        
        if(rb.velocity.x<5.0f)
        {
            rb.AddForce(new Vector2(10.0f, 0.0f));
        }



        if (hasHitFloor && Input.GetKeyDown("up"))
        {
            //first jump
            rb.AddForce(new Vector2(0.0f, 100.0f));
            hasSecondJumped = false;
            hasHitFloor = false;
        }
        if (!hasSecondJumped && Input.GetKeyDown("up"))
        {
            //second jump
            rb.AddForce(new Vector2(-100.0f,100.0f));
            hasSecondJumped = true;
        }

        

        transform.up = Vector3.up;
	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        //if collision is a floor
        if (collision.transform.position.y + collision.collider.bounds.size.y / 2.0f < transform.position.y - rend.bounds.size.y / 2.0f)
        {
            hasHitFloor = true;
        }
    }
}
