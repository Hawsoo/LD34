using UnityEngine;
using System.Collections;

public class PotatoGrow : MonoBehaviour {

    public bool IsLarge = false;
    public GameObject PotatoSmall;
    public GameObject PotatoLarge;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        PotatoSmall.SetActive(!IsLarge);
        PotatoLarge.SetActive(IsLarge);
	}

    void SetIsLarge(bool isLarge)
    {
        IsLarge = isLarge;
    }
}
