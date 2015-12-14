using UnityEngine;
using System.Collections;

public class AudioUtils : MonoBehaviour {

    public static AudioSource Audio;

	// Use this for initialization
	void Start () {
        Audio = GetComponent<AudioSource>();
	}
}
