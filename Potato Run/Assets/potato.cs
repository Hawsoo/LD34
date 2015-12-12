using UnityEngine;
using System.Collections;

public class potato : MonoBehaviour {

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //if(Input.GetButton("w"))
        //{
        //    rb.AddForce(0.0f, 100.0f,0.0f,ForceMode.Impulse);
        //}
    }
}
