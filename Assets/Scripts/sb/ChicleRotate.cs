using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChicleRotate : MonoBehaviour {

    public float VelocidadRotacion;
    public bool RotateLeft;
    public bool RotateRight;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(RotateLeft == true)
        {
            transform.Rotate(Vector3.back, -VelocidadRotacion);
        }

        if(RotateRight == true)
        {
            transform.Rotate(Vector3.back, VelocidadRotacion);
        }
	}
}
