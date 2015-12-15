using UnityEngine;
using System.Collections;

public class PotatoGrow : MonoBehaviour {

    public bool IsLarge = false;
    private bool IsLargePrev;
    public GameObject PotatoSmall;
    public GameObject PotatoLarge;

    public AudioClip PowerUp;
	public AudioClip HurtSnd;

	public float HurtDuration;
	private float HurtTimeWaited;

	// Use this for initialization
	void Start () {
        IsLargePrev = IsLarge;
		HurtTimeWaited = HurtDuration;
	}
	
	// Update is called once per frame
	void Update () {
        if (IsLargePrev != IsLarge)
        {
            IsLargePrev = IsLarge;

			if (IsLarge)
			{
            	AudioUtils.Audio.PlayOneShot(PowerUp);
			}
			else
			{
				AudioUtils.Audio.PlayOneShot(HurtSnd);
			}

            PotatoSmall.SetActive(!IsLarge);
            PotatoLarge.SetActive(IsLarge);
        }

		HurtTimeWaited += Time.deltaTime;

		// Die if fallen
		if (transform.position.y < -50) {
			// Die
			GameOverPrompt.ReplayLevelName = Application.loadedLevelName;
			Application.LoadLevel("DeathMenu");
		}
	}

    void SetIsLarge(bool isLarge)
    {
        IsLarge = isLarge;
    }

	void Hurt()
	{
		if (HurtDuration <= HurtTimeWaited)
		{
			if (IsLarge) {
				IsLarge = false;
				HurtTimeWaited = 0;
			} else {
				// Die
				GameOverPrompt.ReplayLevelName = Application.loadedLevelName;
				Application.LoadLevel("DeathMenu");
			}
		}
	}
}
