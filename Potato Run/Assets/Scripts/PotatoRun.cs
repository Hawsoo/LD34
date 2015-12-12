﻿using UnityEngine;
using System.Collections;

public class PotatoRun : MonoBehaviour {

    public bool Move = false;
    public float ConstantMvtSpeed = 10f;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Move)
        {
            Vector3 m = rb.velocity;
            rb.velocity = new Vector3(ConstantMvtSpeed, m.y, m.z);
        }
	}
}