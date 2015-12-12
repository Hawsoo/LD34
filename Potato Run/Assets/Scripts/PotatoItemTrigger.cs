using UnityEngine;
using System.Collections;

public class PotatoItemTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerStay2D (Collider2D other) {
        if (other.gameObject.tag == "Item")
        {
            // Execute item properties
            ItemProperties ip = other.GetComponent<ItemProperties>();
            ip.ScriptExecute.SendMessage(ip.MessageName);
        }
	}
}
