using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public AudioClip MenuTick;

    private int selected;
    [SerializeField]
    private GameObject NotEaten;
    [SerializeField]
    private GameObject CatchMe;
    [SerializeField]
    private GameObject SpudsAway;
    private Vector3 vec1;
    private Vector3 vec2;
    private Vector3 vec3;
    private float width1;
    private float width2;
    private float width3;
    [SerializeField]
    private string level1;
    [SerializeField]
    private string level2;
    [SerializeField]
    private string level3;

    // Use this for initialization
    void Start () {
        selected = 0;
        width1 = 1;
        width2 = 0;
        width3 = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("up"))
        {
			AudioUtils.Audio.PlayOneShot(MenuTick);
            selected++;
            if (selected > 2)
            {
                selected -= 3;
            }
        }

        if (selected == 0)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Application.LoadLevel(level1);
            }
            width1 = 0.3f;
            width2 = 0;
            width3 = 0;
        }
        if (selected == 1)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Application.LoadLevel(level2);
            }
            width1 = 0;
            width2 = 0;
            width3 = 0.3f;
        }
        if (selected == 2)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Application.LoadLevel(level3);
            }
            width1 = 0;
            width2 = 0.3f;
            width3 = 0;
        }

        float width = NotEaten.GetComponent<Renderer>().bounds.size.x;
        vec1 = NotEaten.transform.position;
        NotEaten.transform.position = new Vector3(width/2.0f+width1, vec1.y, vec1.z);

        width = CatchMe.GetComponent<Renderer>().bounds.size.x;
        vec2 = CatchMe.transform.position;
        CatchMe.transform.position = new Vector3(width / 2.0f + width2, vec2.y, vec2.z);

        width = SpudsAway.GetComponent<Renderer>().bounds.size.x;
        vec3 = SpudsAway.transform.position;
        SpudsAway.transform.position = new Vector3(width / 2.0f + width3, vec3.y, vec3.z);

    }
}
