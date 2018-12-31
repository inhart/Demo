using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieFollowOnRange : MonoBehaviour {

    GameObject Player;
    public bool IsInRange = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IsInRange = true;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IsInRange = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        IsInRange = false;
    }
}
