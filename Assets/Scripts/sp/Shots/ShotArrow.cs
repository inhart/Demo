using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotArrow : MonoBehaviour
{
    float speed = 4;

    public GameObject chainGFX;

    Vector2 startPos;

    // Use this for initialization
    void Start()
    {
        startPos = transform.position;
        GameObject chain = Instantiate(chainGFX, transform.position, Quaternion.identity);
        chain.transform.parent = transform;

        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
        if ((transform.position.y - startPos.y) >= 0.2f)
        {
            GameObject chain = Instantiate(chainGFX, transform.position, Quaternion.identity);
            chain.transform.parent = transform;

            startPos = transform.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.name.Contains("DestroyBall"))
        {        
            BallManager.bm.Dinamite(6);

        }
        if (collision.gameObject.name.Contains("StopBall"))
        {
            FreezeManager.fm.StartFreeze(6);

        }
        if (collision.gameObject.tag == "ball")
        {
            collision.gameObject.GetComponent<Ball>().Split();
           
        }
        if (collision.gameObject.tag == "Hexagon")
        {
            collision.gameObject.GetComponent<Hexagon>().Split();
        }
      

        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "leader")
        {

            Destroy(gameObject);
            ShootManager.shm.DestroyShot();
        }
    }


}
