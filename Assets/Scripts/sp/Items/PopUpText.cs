using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpText : MonoBehaviour {

    public Vector2 startPos;
	// Use this for initialization
	void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * 2 * Time.deltaTime);
        if(transform.position.y> startPos.y +2)
        {
            Destroy(gameObject);
        }
	}
}
