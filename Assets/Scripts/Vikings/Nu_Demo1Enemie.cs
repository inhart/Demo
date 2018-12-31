using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nu_Demo1Enemie : MonoBehaviour {

    public Slider enemieHealthSlider;
    public Slider redHealthSlider;
    public float enemieHealth = 100;
    public bool doanim = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        enemieHealthSlider.value = enemieHealth;
        if(doanim == true)
        {
            redHealthSlider.value -= 1.0f;
        }
        if (redHealthSlider.value <= enemieHealthSlider.value)
        {
            redHealthSlider.value = enemieHealthSlider.value;
        }
	}


    private void OnCollisionStay2D(Collision2D collision)
    {
        if((collision.gameObject.tag == "Player") && (Input.GetButtonDown("Fire1")))
        {
            enemieHealth -= 25.0f;
            doanim = true;
        }
    }
}
