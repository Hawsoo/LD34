using UnityEngine;
using System.Collections;

public class HardBlockBehavior : MonoBehaviour {

    public AudioClip BreakBlock;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    // Check if player is large
        if (LevelInfo._player.GetComponent<PotatoGrow>().IsLarge &&
            LevelInfo._player.GetComponent<PotatoMovement>().IsCharging)
        {
            // Set collision to trigger
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
        else
        {
            // Set collision to collision
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.root.gameObject == LevelInfo._player &&
            LevelInfo._player.GetComponent<PotatoGrow>().IsLarge &&
            LevelInfo._player.GetComponent<PotatoMovement>().IsCharging)
        {
            AudioUtils.Audio.PlayOneShot(BreakBlock);
            Destroy(gameObject);
        }
    }
}
