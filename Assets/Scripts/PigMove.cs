using UnityEngine;
using System.Collections;

public class PigMove : MonoBehaviour {

    private Rigidbody2D rb;
    private bool moveRight;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        moveRight = true;

	}
	
	// Update is called once per frame
	void Update () {
        if (moveRight)
        {
            rb.velocity = new Vector2(1.0f, 0.0f);
        }
        else
        {
            rb.velocity = new Vector2(-1.0f, 0.0f);
        }
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            moveRight = !moveRight;
        }
    }
}
