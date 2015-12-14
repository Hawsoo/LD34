using UnityEngine;
using System.Collections;

public class PotatoMechanim : MonoBehaviour {

    public Animator SmallPotato;
    public Animator LargePotato;

    public bool OverrideMechanim = false;
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!OverrideMechanim)
        {
            if (GetComponent<PotatoGrow>().IsLarge)
            {
                LargePotato.SetBool("OnGround", GetComponent<PotatoMovement>().hasHitFloor);
            }
            else
            {
                SmallPotato.SetBool("OnGround", GetComponent<PotatoMovement>().hasHitFloor);
            }
        }

        // Undo flag
        OverrideMechanim = false;
	}
}
