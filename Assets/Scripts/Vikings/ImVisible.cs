using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImVisible : MonoBehaviour {
    public bool visible;
	// Use this for initialization
	void Start () {
		
	}
	
	
    private void OnBecameVisible()
    {
        visible = true;
    }
    private void OnBecameInvisible()
    {
        visible = false;
    }
}
