using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public GameObject player;
    public float distance;
	// Use this for initialization
	void Start () {
        transform.LookAt(player.transform.position);
        transform.position = player.transform.position - (transform.forward * distance);
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position - (transform.forward * distance);


    }
}
