using UnityEngine;
using System.Collections;

public class FloorCollider : MonoBehaviour {

    void OnTriggerStay2D(Collider2D other)
    {
        SendMessageUpwards("FloorCollision");
    }
}
