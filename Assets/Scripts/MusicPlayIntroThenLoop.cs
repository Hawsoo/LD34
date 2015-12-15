using UnityEngine;
using System.Collections;

public class MusicPlayIntroThenLoop : MonoBehaviour {

    public AudioClip Intro;
    public AudioClip Loop;

    private AudioSource AS;

	// Use this for initialization
	void Start () {
        AS = GetComponent<AudioSource>();

        AS.clip = Intro;
        AS.loop = false;
        AS.Play();
	}
	
	// Update is called once per frame
	void Update () {
        if (AS.clip == Intro && !AS.isPlaying)
        {
            AS.clip = Loop;
            AS.loop = true;
            AS.Play();
        }
	}
}
