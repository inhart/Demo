using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftFlip : MonoBehaviour {

    public GameObject part1;
    public GameObject part2;
    public GameObject part3;
    public GameObject part4;
    public GameObject part5;
    public GameObject part6;
    public GameObject part7;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            part1.GetComponent<SpriteRenderer>().flipX = false;
            part2.GetComponent<SpriteRenderer>().flipX = false;
            part3.GetComponent<SpriteRenderer>().flipX = false;
            part4.GetComponent<SpriteRenderer>().flipX = false;
            part5.GetComponent<SpriteRenderer>().flipX = false;
            part6.GetComponent<SpriteRenderer>().flipX = false;
            part7.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
