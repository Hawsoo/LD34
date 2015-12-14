using UnityEngine;
using System.Collections;

public class HardBlockBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    // Check if player is large
        if (LevelInfo._player.GetComponent<PotatoGrow>().IsLarge)
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

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);

        if (other.transform.root.gameObject == LevelInfo._player &&
            LevelInfo._player.GetComponent<PotatoGrow>().IsLarge)
        {
            Destroy(gameObject);
        }
    }
}
