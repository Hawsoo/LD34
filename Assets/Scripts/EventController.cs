using UnityEngine;
using System.Collections;

public class EventController : MonoBehaviour {
    public int score;
    public float timer;
    public GameObject player;
    public bool hasWon = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (hasWon)
        {
            WinCommand();
        }
	
	}
    void WinCommand()
    {
        this.enabled = false;
    }
}
