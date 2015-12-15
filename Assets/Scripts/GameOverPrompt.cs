using UnityEngine;
using System.Collections;

public class GameOverPrompt : MonoBehaviour {

	public static string ReplayLevelName;

	// Update is called once per frame
	void Update () {
        if (Input.GetKey("up"))
        {
			Application.LoadLevel(ReplayLevelName);
        }

		if (Input.GetKey ("right")) {
			Application.LoadLevel("MainMenu");
		}
	}
}
