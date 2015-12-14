using UnityEngine;
using System.Collections;

public class LevelInfo : MonoBehaviour {

    public GameObject Player; public static GameObject _player;

	// Use this for initialization
	void Start () {
        _player = Player;
	}
}
