﻿using UnityEngine;
using System.Collections;

public class animationTester : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GetComponent<Animation>().Play("Impact");
        }
    }
}