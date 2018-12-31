using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitlerController : MonoBehaviour {

    HitlerBoss Ef_or;
    private Vector3 velocity;
    public Transform target;

    public int EnemieHealth = 1000;
    public Slider EnemieHealthSlider;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Ef_or = gameObject.GetComponentInChildren<HitlerBoss>();
    }

    // Update is called once per frame
    void Update () {
		if((Ef_or.IsInRange == true) && (GameObject.Find("ChicaSexy").GetComponent<PlayerController_tp>().dead == false))
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position + new Vector3(0,500), 200 * Time.deltaTime);
            gameObject.GetComponent<Animator>().SetBool("OnRange", true);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("OnRange", false);
        }
        EnemieHealthSlider.value = EnemieHealth;
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            EnemieHealth -= 100;
        }
    }
}
