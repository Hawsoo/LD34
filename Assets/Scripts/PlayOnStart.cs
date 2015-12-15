using UnityEngine;
using System.Collections;

public class PlayOnStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<AudioSource>().Play();
	}
}
