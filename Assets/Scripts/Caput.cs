using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caput : MonoBehaviour {

    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if(other.gameObject.name.Contains("Player"))
        {
            Debug.Log("segunda");
            other.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            other.transform.position = other.gameObject.GetComponent<PlayerMovement>().lastPos;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
       
        other.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
    }
}
