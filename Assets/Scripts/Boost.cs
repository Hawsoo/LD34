using UnityEngine;
using System.Collections;

public class Boost : MonoBehaviour {
    public float boostFactor;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<Rigidbody2D>().velocity += Vector2.right * boostFactor;
    }
}
