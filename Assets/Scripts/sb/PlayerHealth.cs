using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float Vida;

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Vida <= 0)
        {
            Destroy(gameObject);
        }
	}

    public void Daño(float Cantidad)
    {
        Vida -= Cantidad;
    }
}
