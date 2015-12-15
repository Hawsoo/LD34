using UnityEngine;
using System.Collections;

public class CameraPointUp : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        transform.up = Vector3.up;
	}
}
