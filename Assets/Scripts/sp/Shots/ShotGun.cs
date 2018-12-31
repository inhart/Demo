using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour {
    float speed = 8f;

	
	// Update is called once per frame
	void Update ()
    {
        if(transform.rotation.z == 0)
        {
            transform.position += Vector3.up * Time.deltaTime * speed;
        }
        else if(transform.rotation.z < 0)
        {
            transform.position += new Vector3(.1f,1) * Time.deltaTime * speed;
        }
        else
        {
            transform.position += new Vector3(-.1f, 1) * Time.deltaTime * speed;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "zapaia")
        {
          
        }
        if (collision.gameObject.tag == "ball")
        {
            collision.gameObject.GetComponent<Ball>().Split();
            
        }
        if (collision.gameObject.tag == "Hexagon")
        {
            collision.gameObject.GetComponent<Hexagon>().Split();
           
        }
        Destroy(gameObject);
        ShootManager.shm.DestroyShot();
    }
}
