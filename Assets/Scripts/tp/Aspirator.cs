using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aspirator : MonoBehaviour {

    //public float smoothTime = 1f;
    //private Vector3 smoothVelocity = new Vector3(100,0);
    public bool isin = false;
    public GameObject collisionedEnemie;
    public GameObject collisionedEnemie2;
    public GameObject collisionedEnemie3;
    public GameObject Hitler;
    private Vector3 velocity;
    EnemieController E_c;
    public GameObject Heart;
    public bool dead = false;

    // Use this for initialization
    void Start () {
        velocity = new Vector3(1f, 0f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isin == true)
        {
            if (Hitler!= null)
            {
                Hitler.GetComponent<HitlerController>().EnemieHealth -= 2;

            }
            if (collisionedEnemie != null)
            {
                collisionedEnemie.GetComponent<EnemieController>().EnemieHealth -= 2;
                collisionedEnemie.GetComponent<Animation>().Play();
            }
            if ((collisionedEnemie != null) && (collisionedEnemie.GetComponent<EnemieController>().EnemieHealth <= 0))
            {
                collisionedEnemie.GetComponent<BoxCollider2D>().isTrigger = true;
                collisionedEnemie.GetComponent<Rigidbody2D>().MovePosition(gameObject.transform.position + velocity * Time.fixedDeltaTime);
                collisionedEnemie.transform.localScale -= new Vector3(4f, 4f, 4f);
                collisionedEnemie.transform.Rotate(0, 0, 10.0f);
                Destroy(collisionedEnemie, 0.2f);
                dead = true;
                int RandomScore = Random.Range(0, 1);
                if (RandomScore == 0)
                {
                    GameController_tp.Score += 10;
                }
                else
                {
                    GameController_tp.Score += 20;
                }
                int RandomPower = Random.Range(0, 1);
                if (RandomPower == 0)
                {
                    PowerController.playerPower += Random.Range(1, 2);
                }
                else
                {
                    PowerController.playerPower += Random.Range(4, 5);
                }
                if(dead == true)
                {
                    int Randomd = Random.Range(0, 100);
                    Debug.Log(Randomd);
                    if (Randomd <= 3)
                    {
                        Instantiate(Heart, collisionedEnemie.transform.position, collisionedEnemie.transform.rotation);
                        dead = false;
                    }
                    else
                    {
                        
                        dead = false;
                    }
                }
            }
            if ((Hitler != null) && (Hitler.GetComponent<HitlerController>().EnemieHealth <= 0))
            {
                Hitler.GetComponent<BoxCollider2D>().isTrigger = true;
                Hitler.GetComponent<Rigidbody2D>().MovePosition(gameObject.transform.position + velocity * Time.fixedDeltaTime);
                Hitler.transform.localScale -= new Vector3(10f, 10f, 10f);
                Hitler.transform.Rotate(0, 0, 30.0f);
                Destroy(Hitler, 0.2f);
                int RandomScore = Random.Range(0, 1);
                if (RandomScore == 0)
                {
                    GameController_tp.Score += Random.Range(1001, 1508);
                }
                else
                {
                    GameController_tp.Score += Random.Range(2002, 2503);
                }
                int RandomPower = Random.Range(0, 1);
                if (RandomPower == 0)
                {
                    PowerController.playerPower += Random.Range(1, 2);
                }
                else
                {
                    PowerController.playerPower += Random.Range(4, 5);
                }
            }

            if ((collisionedEnemie2 != null) && (collisionedEnemie.GetComponent<EnemieController>().EnemieHealth <= 0))
            {
                collisionedEnemie2.GetComponent<BoxCollider2D>().isTrigger = true;
                collisionedEnemie2.GetComponent<Rigidbody2D>().MovePosition(gameObject.transform.position + velocity * Time.fixedDeltaTime);
                collisionedEnemie2.transform.localScale -= new Vector3(4f, 4f, 4f);
                collisionedEnemie2.transform.Rotate(0, 0, 10.0f);
                Destroy(collisionedEnemie2, 0.2f);
                int RandomScore = Random.Range(0, 1);
                if (RandomScore == 0)
                {
                    if(collisionedEnemie.tag == "Enemie")
                    {
                        GameController_tp.Score += 10;
                    }
                    else
                    {
                        GameController_tp.Score += 100;
                    }
                }
                else
                {
                    if (collisionedEnemie.tag == "Enemie")
                    {
                        GameController_tp.Score += 20;
                    }
                    else
                    {
                        GameController_tp.Score += 200;
                    }
                }
                int RandomPower = Random.Range(0, 1);
                if (RandomPower == 0)
                {
                    PowerController.playerPower += Random.Range(1, 2);
                }
                else
                {
                    PowerController.playerPower += Random.Range(4, 5);
                }
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemie")
        {
            GameObject.Find("AudioContainer3").GetComponent<AudioSource>().Play();
        }
        if (collision.gameObject.tag == "Hitler")
        {
            GameObject.Find("AudioContainer3").GetComponent<AudioSource>().Play();
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemie")
        {
            isin = true;
            collisionedEnemie = collision.gameObject;
            E_c = collisionedEnemie.GetComponent<EnemieController>();
            E_c.DoDamage = true;
            E_c.DoDamageSliderAnim();
        }
        if (collision.gameObject.tag == "Hitler")
        {
            isin = true;
            Hitler = collision.gameObject;
            E_c = collisionedEnemie.GetComponent<EnemieController>();
            E_c.DoDamage = true;
            E_c.DoDamageSliderAnim();
            
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        isin = false;
        if(collision.gameObject.tag == "Enemie")
        {
            collisionedEnemie = null;
            collisionedEnemie2 = null;
            collisionedEnemie3 = null;
            Destroy(collisionedEnemie);
            Destroy(collisionedEnemie2);
            Destroy(collisionedEnemie3);
            E_c.DoDamage = false;
        }
        if (collision.gameObject.tag == "Hitler")
        {
            Hitler = null;
        }
    }
}
