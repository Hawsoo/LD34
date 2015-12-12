using UnityEngine;
using System.Collections;

public class potato : MonoBehaviour {

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private PotatoRun pr;
    private bool isGrabbing;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        pr = GetComponent<PotatoRun>();
        isGrabbing = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown("up")&&bc.isTrigger)
        {
            //first jump
            rb.AddForce(new Vector2(0.0f, 100.0f));
        }
        if (rb.velocity.x > 0 && bc.isTrigger)
        {
            isGrabbing = true;
        }
        if (isGrabbing && Input.GetKeyDown("up"))
        {
            //second jump
            rb.AddForce(new Vector2(-1.0f, 100.0f));
            isGrabbing = false;
        }

        transform.up = Vector3.up;
	}
}
