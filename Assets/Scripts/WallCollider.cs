using UnityEngine;
using System.Collections;

public class WallCollider : MonoBehaviour {

	void OnTriggerStay2D(Collider2D other)
    {
        SendMessageUpwards("WallCollision");
    }
}
