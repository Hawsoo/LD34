using UnityEngine;
using System.Collections;

public class PotatoGrow : MonoBehaviour {

    public bool IsLarge = false;
    private bool IsLargePrev;
    public GameObject PotatoSmall;
    public GameObject PotatoLarge;
    public AudioClip PowerUp;

	// Use this for initialization
	void Start () {
        IsLargePrev = IsLarge;
	}
	
	// Update is called once per frame
	void Update () {
        if (IsLargePrev != IsLarge)
        {
            IsLargePrev = IsLarge;
            AudioSource.PlayClipAtPoint(PowerUp, Vector3.zero);

            PotatoSmall.SetActive(!IsLarge);
            PotatoLarge.SetActive(IsLarge);
        }
	}

    void SetIsLarge(bool isLarge)
    {
        IsLarge = isLarge;
    }
}
