using UnityEngine;
using System.Collections;

public class MovingMenuGround : MonoBehaviour {

	public bool XAxis;
	public bool YAxis;
	public bool ZAxis;

	public float Speed;

	public float DeleteTime = 15;
	public float TimeWaited;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		
		if (XAxis) pos.x += Speed * Time.deltaTime;
		if (YAxis) pos.y += Speed * Time.deltaTime;
		if (ZAxis) pos.z += Speed * Time.deltaTime;

		transform.position = pos;

		// Keep track of time
		TimeWaited += Time.deltaTime;
		if (DeleteTime <= TimeWaited) {
			Destroy(gameObject);
		}
	}
}
