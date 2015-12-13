using UnityEngine;
using System.Collections;

public class objectMove : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        Vector3 position = transform.position;
        transform.position = new Vector3(position.x-0.08f,position.y,position.z);
        if(transform.position.x < -20)
        {
            Destroy(this.gameObject);
        }
	}
}
