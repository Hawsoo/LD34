using UnityEngine;
using System.Collections;

public class potato : MonoBehaviour {

    private Rigidbody2D rb;
    private float dy;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        dy = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("w"))
        {
            dy += 5.0f;
        }

        rb.velocity = new Vector2(0.0f, dy);
        
	}
}
