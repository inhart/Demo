using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public float Vida;
    public float velocidad;
    public float velocidadPelota;
    public float Daño;
    public float RecoveryTime;

    float Movement;
    public PlayerHealth PH;
    public ChicleRotate CR;
    public GameObject GameManager;
    public GameObject[] Gums;
    public Sprite[] Dientes;
    public bool Dañable;
    public bool Desplazar;
    public bool MoveIzquierda;
    public bool MoveDerecha;
    public bool IzquierdaPelota;
    public bool DerechaPelota;
    public bool Curable;
    // Use this for initialization
    void Start()
    {
        Curable = true;
        Dañable = true;
        Desplazar = true;
        MoveIzquierda = true;
        MoveDerecha = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((MoveIzquierda == true) && (Desplazar == true))
        {
            gameObject.GetComponent<Rigidbody2D>().rotation = 0f;
            gameObject.GetComponent<Transform>().Translate(Vector2.left * velocidad);          
        }

        if((MoveDerecha == true) && (Desplazar == true))
        {
            gameObject.GetComponent<Rigidbody2D>().rotation = 0f;
            gameObject.GetComponent<Transform>().Translate(Vector2.left * -velocidad);
        }

        if(IzquierdaPelota == true)
        {
            CR.RotateRight = false;
            CR.RotateLeft = true;
            gameObject.GetComponent<Transform>().Translate(Vector2.left * velocidadPelota);
        }
        
        if(DerechaPelota == true)
        {
            CR.RotateLeft = false;
            CR.RotateRight = true;
            gameObject.GetComponent<Transform>().Translate(Vector2.left * -velocidadPelota);
        }

        if(Vida < 150f)
        {
            Vida += 0.17f;
        }

        if (Dañable == true)
        {
            if (Vida > 120)
            {
                Desplazar = true;
                gameObject.GetComponent<SpriteRenderer>().sprite = Dientes[0];
                gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                Gums[0].SetActive(false);
                Gums[1].SetActive(false);
                Gums[2].SetActive(false);
                Gums[3].SetActive(false);
            }

            if ((Vida > 90) && (Vida <= 120))
            {
                Desplazar = false;
                gameObject.GetComponent<SpriteRenderer>().sprite = Dientes[1];
                gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                Gums[0].SetActive(false);
                Gums[1].SetActive(false);
                Gums[2].SetActive(false);
                Gums[3].SetActive(true);

            }

            if ((Vida <= 90) && (Vida > 60))
            {
                Desplazar = false;
                gameObject.GetComponent<SpriteRenderer>().sprite = Dientes[1];
                gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                Gums[0].SetActive(false);
                Gums[1].SetActive(false);
                Gums[3].SetActive(false);
                Gums[2].SetActive(true);
            }

            if ((Vida <= 60) && (Vida > 30))
            {
                Desplazar = false;
                gameObject.GetComponent<SpriteRenderer>().sprite = Dientes[1];
                gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                Gums[0].SetActive(false);              
                Gums[2].SetActive(false);
                Gums[3].SetActive(false);
                Gums[1].SetActive(true);
            }

            if (Vida <= 30)
            {
                Dañable = false;
                Desplazar = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
                Gums[1].SetActive(false);
                Gums[2].SetActive(false);
                Gums[3].SetActive(false);
                Gums[0].SetActive(true);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Bala")
        {
            Vida -= 10f;
            GameManager.GetComponent<GameManagerr>().Score += 10;
        }

        if ((coll.gameObject.name == "LimitePlataformaLeft") && (Desplazar == true))
        {
            MoveIzquierda = false;
            MoveDerecha = true;
        }

        if ((coll.gameObject.name == "LimitePlataformaRight") && (Desplazar == true))
        {
            MoveDerecha = false;
            MoveIzquierda = true; 
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(((coll.gameObject.name == "LimiteKill") || (coll.gameObject.name == "LimiteKill2")) && (Curable == false))
        {
            GameManager.GetComponent<GameManagerr>().Score += 150f;
            Destroy(gameObject);
        }

        if((coll.gameObject.tag == "Enemigo") && (Dañable == false))
        {
            GameManager.GetComponent<GameManagerr>().Score += 100f;
            Destroy(coll.gameObject);
        }

        if(coll.gameObject.name == "LimiteLeft")
        {
            IzquierdaPelota = false;
            DerechaPelota = true;
            gameObject.GetComponent<Rigidbody2D>().rotation = 0f;
        }

        if(coll.gameObject.name == "LimiteRight")
        {
            DerechaPelota = false;
            IzquierdaPelota = true;
            gameObject.GetComponent<Rigidbody2D>().rotation = 0f;
        }

        if ((coll.gameObject.tag == "Player") && (Dañable == true) && (Desplazar == true))
        {
            PH.Daño(20f);
            coll.gameObject.GetComponent<PlayerMovement_sb>().movimiento = false;

            foreach (ContactPoint2D choquePos in coll.contacts)
            {
                if ((choquePos.normal.x > 0) && (coll.gameObject.GetComponent<PlayerMovement_sb>().saltando == false)) // Colisión izquierda;
                {
                    coll.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-75.0f, 125.0f));                  
                    Debug.Log("Choque izquierda");
                }

                if ((choquePos.normal.x < 0) && (coll.gameObject.GetComponent<PlayerMovement_sb>().saltando == false)) // Colisión derecha;
                {
                    coll.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(75.0f, 125.0f));
                    Debug.Log("Choque derecha");
                }

                if ((choquePos.normal.y > 0) && (coll.gameObject.GetComponent<PlayerMovement_sb>().saltando == false)) // Colisión abajo;
                {
                    coll.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, -125.0f));
                    Debug.Log("Choque abajo");
                }

                if ((choquePos.normal.x > 0) && (coll.gameObject.GetComponent<PlayerMovement_sb>().saltando == true)) // Colisión izquierda salto;
                {
                    coll.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-15.0f, 15.0f));
                    Debug.Log("Choque izquierda saltando");
                }

                if ((choquePos.normal.x < 0) && (coll.gameObject.GetComponent<PlayerMovement_sb>().saltando == true)) // Colisión derecha salto;
                {
                    coll.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(15.0f, 15.0f));
                    Debug.Log("Choque derecha saltando");
                }

                if ((choquePos.normal.y < 0) && (coll.gameObject.GetComponent<PlayerMovement_sb>().saltando == true)) // Colisión arriba salto;
                {
                    coll.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 100.0f));
                    Debug.Log("Choque arriba saltando");
                }
            }
        }

       
    }
}
