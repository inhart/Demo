using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xbox : MonoBehaviour {
    public List<string> botones;
	// Use this for initialization
	void Start () {
        botones.AddRange(Input.GetJoystickNames());
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            print("Fire1");
        }
        if (Input.GetButtonDown("Fire2"))
        {
            print("Fire2");
        }
        if (Input.GetButtonDown("Fire3"))
        {
            print("Fire3");
        }
        
    }
}
