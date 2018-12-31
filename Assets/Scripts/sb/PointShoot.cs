using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointShoot : MonoBehaviour
{
    public GameObject Bala;
    public bool Disparar;
    float siguienteDisparo = 0f;
    public float cadenciaDisparo;
    public float balaVelocidad;
    public PlayerMovement_sb PM;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if ((Input.GetKey(KeyCode.J)) && (Disparar == true))
        {
            if(PM.Derecha == true)
            {
                GameObject laBala = Instantiate(Bala, (gameObject.transform.position), gameObject.transform.rotation);
                laBala.GetComponent<Rigidbody2D>().AddForce(laBala.transform.right * balaVelocidad);
            }
            
            if(PM.Izquierda == true)
            {
                GameObject laBala = Instantiate(Bala, (gameObject.transform.position), gameObject.transform.rotation);
                laBala.GetComponent<Rigidbody2D>().AddForce(-laBala.transform.right * balaVelocidad);
                laBala.GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        if (Time.time > siguienteDisparo)
        {
            siguienteDisparo = Time.time + cadenciaDisparo;
            Disparar = true;
        }
        else
        {
            Disparar = false;
        }
    }
}
