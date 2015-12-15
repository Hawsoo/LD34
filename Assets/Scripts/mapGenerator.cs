using UnityEngine;
using System.Collections;

public class mapGenerator : MonoBehaviour {

    [SerializeField]
    private GameObject floor;

    [SerializeField]
    private GameObject wall;

    private int count = 0;

    void Update()
    {
        if(count == 30 || count == 20 || count == 10)
        {
            makeFloor();
        }
        if(count==40)
        {
            makeWall();
            count = 0;
        }
        count++;
    }

    void makeFloor()
    {
        Instantiate(floor, new Vector3(20, Random.Range(-15.0f,15.0f), 0), Quaternion.identity);
    }

    void makeWall()
    {
        Instantiate(wall, new Vector3(20, Random.Range(-15.0f, 15.0f), 0), Quaternion.identity);
    }
}
