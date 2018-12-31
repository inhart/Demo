using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow_Behavior : MonoBehaviour
{
    public GameObject bola;
    public List<GameObject> bolas;
    public int maxBalls = 3;
    public bool canShoot = true;
    public float fuerza = 500;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            if (Input.GetButtonDown("Fire1"))
            {

                
                    if (transform.localScale.x > 0)
                    {
                        Vector3 pose = new Vector3(transform.position.x + bola.GetComponent<CircleCollider2D>().radius * 2, transform.position.y, 0f);
                        GameObject ball = Instantiate(bola, pose, Quaternion.identity);
                        bolas.Add(ball);
                    ball.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(fuerza, fuerza / 2));
                    }
                   else
                    {
                        Vector3 pose = new Vector3(transform.position.x - bola.GetComponent<CircleCollider2D>().radius * 2, transform.position.y, 0f);
                        GameObject ball = Instantiate(bola, pose, Quaternion.identity);
                        bolas.Add(ball);
                    ball.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-fuerza, fuerza / 2));
                }
                
                if (bolas.Count >= maxBalls)
                {
                    canShoot = false;
                }
            }
           
        }

        if (Input.GetButtonDown("Fire2"))
        {
            if (bolas.Count != 0)
            {
                Destroy(bolas[0]);
                bolas.Remove(bolas[0]);

            }
            if (bolas.Count < maxBalls)
            {
                canShoot =true;
            }
        }
    }
}
