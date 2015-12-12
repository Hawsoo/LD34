using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float scaleFactor = 1.5f;
    private Rigidbody rb;
    private Vector3 targetScale;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        targetScale = transform.localScale;
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale = Vector3.MoveTowards(transform.localScale, targetScale, .1f);

    }
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Space))
            
            {
            
            
            targetScale = transform.localScale * scaleFactor;
        }
        



    }
}
