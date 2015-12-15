using UnityEngine;
using System.Collections;

public class GoalBehavior : MonoBehaviour {

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.transform.root.gameObject.tag == "Player")
		{
			// End level
			GameOverPrompt.ReplayLevelName = Application.loadedLevelName;
			Application.LoadLevel("WinMenu");
		}
	}
}
