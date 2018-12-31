using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAncla : MonoBehaviour
{

    float speed = 4;

    public GameObject chainGFX;

    Vector2 startPos;

    List<GameObject> chains = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        startPos = transform.position;
        GameObject chain = Instantiate(chainGFX, transform.position, Quaternion.identity);
        chain.transform.parent = transform;

        chains.Add(chain);
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
            chains.Add(chain);
            startPos = transform.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "zapaia")
        {

            StartCoroutine(DestroyAncle());
        }
        if (collision.gameObject.tag == "ball")
        {
            collision.gameObject.GetComponent<Ball>().Split();
            Destroy(gameObject);
            ShootManager.shm.DestroyShot();
        }
        if (collision.gameObject.tag == "Hexagon")
        {
            collision.gameObject.GetComponent<Hexagon>().Split();
            Destroy(gameObject);
            ShootManager.shm.DestroyShot();
        }
    }

    IEnumerator DestroyAncle()
    {
        speed = 0;
        yield return new WaitForSeconds(1);
        foreach (GameObject item in chains)
        {
            item.GetComponent<SpriteRenderer>().color = Color.red;
        }
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        ShootManager.shm.DestroyShot();

    }
}
