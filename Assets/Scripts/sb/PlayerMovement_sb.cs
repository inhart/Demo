using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement_sb : MonoBehaviour {

    public float velocidad;
    public float salto;
    float siguienteSalto = 0f;
    public float cadenciaSalto;
    public bool movimiento;
    public bool saltando;
    public bool saltoEnable;
    public bool Izquierda;
    public bool Derecha;

    // Use this for initialization
    void Start ()
    {
        Derecha = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.D))) && (movimiento == true))
        {
            if (Input.GetKey(KeyCode.A))
            {
                Derecha = false;
                Izquierda = true;
                gameObject.GetComponent<Transform>().Translate(Vector2.left * velocidad);
                gameObject.GetComponent<Animator>().SetBool("Movimiento", true);
            }

            if (Input.GetKey(KeyCode.D))
            {
                Izquierda = false;
                Derecha = true;
                gameObject.GetComponent<Transform>().Translate(Vector2.right * velocidad);
                gameObject.GetComponent<Animator>().SetBool("Movimiento", true);
            }
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("Movimiento", false);
        }

        if (Input.GetKey(KeyCode.K))
        {
            gameObject.GetComponent<Animator>().SetBool("Baile", true);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("Baile", false);
        }

        if (Input.GetKey(KeyCode.L))
        {
            gameObject.GetComponent<Animator>().SetBool("Saludo", true);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("Saludo", false);
        }

        if ((Input.GetKey(KeyCode.LeftShift)) && (Input.GetKey(KeyCode.I)))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if((Input.GetKey(KeyCode.Space)) && (saltoEnable == true) && (Time.time > siguienteSalto))
        {
            siguienteSalto = Time.time + cadenciaSalto;
            saltoEnable = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, salto));
        }

        if(Izquierda == true)
        {
            gameObject.GetComponent<Transform>().localScale = new Vector3(-0.592f, 0.592f, 0.592f);
        }

        if (Derecha == true)
        {
            gameObject.GetComponent<Transform>().localScale = new Vector3(0.592f, 0.592f, 0.592f);
        }

        if(saltando == true)
        {
            gameObject.GetComponent<Animator>().SetBool("Salto", true);
        }
    }

    void OnCollisionStay2D(Collision2D coliSt)
    {
        if(coliSt.gameObject.tag == "Plataforma")
        {
            saltando = false;
            saltoEnable = true;
            movimiento = true;
            gameObject.GetComponent<Animator>().SetBool("Salto", false);
        }

        if((coliSt.gameObject.tag == "Enemigo") && (coliSt.gameObject.GetComponent<EnemyManager>().Dañable == false))
        {
            Debug.Log("Se puede empujar");
            gameObject.GetComponent<Animator>().SetBool("Empujar", true);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("Empujar", false);
        }

        if ((coliSt.gameObject.tag == "Enemigo") && (coliSt.gameObject.GetComponent<EnemyManager>().Dañable == false) && (Input.GetKey(KeyCode.K)))
        {
            coliSt.gameObject.GetComponent<EnemyManager>().Curable = false;
            coliSt.gameObject.GetComponent<EnemyManager>().IzquierdaPelota = true;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if ((coll.gameObject.tag == "Enemigo") && (coll.gameObject.GetComponent<EnemyManager>().Dañable == false))
        {
            Debug.Log("Se puede empujar");
            gameObject.GetComponent<Animator>().SetBool("Empujar", true);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("Empujar", false);
        }
    }

    void OnCollisionExit2D(Collision2D coliEx)
    {
        if(coliEx.gameObject.tag == "Plataforma")
        {
            saltando = true;
            saltoEnable = false;
        }
    }
}