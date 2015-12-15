using UnityEngine;
using System.Collections;

public class BasicSpawner : MonoBehaviour {

	public GameObject Object;
	public float TimeBetween;
	private float TimeWaited = 0;

	// Use this for initialization
	void Start () {
		InstantiateTheObj();
	}
	
	// Update is called once per frame
	void Update () {
		TimeWaited += Time.deltaTime;

		if (TimeBetween <= TimeWaited) {
			TimeWaited = 0;
			InstantiateTheObj();
		}
	}

	private void InstantiateTheObj()
	{
		GameObject go = GameObject.Instantiate(Object, transform.position, transform.rotation) as GameObject;
		go.transform.parent = transform;
	}
}
