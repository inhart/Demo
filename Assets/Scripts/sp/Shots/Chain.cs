﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour {

	void Update () {
        if (transform.localScale.y < 10f)
        {
            transform.localScale += Vector3.up * Time.deltaTime * 4f;
        }	
	}
}
