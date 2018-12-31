using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

    Animation Am;

	void Start () {
        Am = gameObject.GetComponentInParent<Animation>();
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Am.Play();
        }
    }
}
