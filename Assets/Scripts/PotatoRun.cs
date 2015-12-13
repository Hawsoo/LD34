using UnityEngine;
using System.Collections;

public class PotatoRun : MonoBehaviour {

    public bool Move = false;
    public float ConstantMvtSpeed = 10f;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (rb.velocity.x < 5.0f)
        {
            rb.AddForce(new Vector2(50.0f, 0.0f));
        }
	}
}
