using UnityEngine;
using System.Collections;

public class ItemPowerupMush : MonoBehaviour {

    public GameObject PotatoChar;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void TriggerExecute()
    {
        PotatoChar.SendMessage("SetIsLarge", true);
        Destroy(gameObject);
    }
}
