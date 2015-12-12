using UnityEngine;
using System.Collections;

public class BallSizer : MonoBehaviour {

    [SerializeField]
    private float BallDiameter = 10.0f;

    [SerializeField]
    private float BallMass = 5.0f;

    private Rigidbody rb;
    private Vector3 scale;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.mass = BallMass;

        scale = transform.localScale;
        scale = new Vector3(BallDiameter, BallDiameter, BallDiameter);
        transform.localScale = scale;
	}
	
	// Update is called once per frame
	void Update () {
        getInput();
        scale = new Vector3(BallDiameter, BallDiameter, BallDiameter);
        transform.localScale = scale;
        rb.mass = BallMass;
	}

    void getInput() 
    {
        if (Input.GetKey("up"))
        {
            BallDiameter += 0.2f;
            BallMass += 0.5f;
        }
        if (Input.GetKey("down")&&BallDiameter>0.5f)
        {
            BallDiameter -= 0.2f;
            BallMass -= 0.5f;
        }
    }
}
