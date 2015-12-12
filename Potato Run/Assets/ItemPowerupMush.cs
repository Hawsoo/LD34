using UnityEngine;
using System.Collections;

public class ItemPowerupMush : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void TriggerExecute()
    {
        Debug.Log("Poopoo!!!");
        Destroy(gameObject);
    }
}
