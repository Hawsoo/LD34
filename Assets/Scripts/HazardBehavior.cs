using UnityEngine;
using System.Collections;

public class HazardBehavior : MonoBehaviour {

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.transform.root.gameObject.tag == "Player")
		{
			LevelInfo._player.GetComponent<PotatoGrow>().SendMessage("Hurt");
		}
	}
}
