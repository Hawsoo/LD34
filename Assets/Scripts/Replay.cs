using UnityEngine;
using System.Collections;

public class Replay : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("up"))
        {
            Application.LoadLevel("infiniteRun");
        }
	}
}
