using UnityEngine;
using System.Collections;

public class PigEat : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if potato be small, eat potato
        if(collision.gameObject.tag == "Player" && !collision.gameObject.GetComponentInChildren<PotatoGrow>().IsLarge)
        {
            Application.LoadLevel("DeathMenu");
        }
        else if(collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }



    }
}
