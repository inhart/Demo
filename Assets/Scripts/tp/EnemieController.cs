using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemieController : MonoBehaviour {

    EnemieFollowOnRange Ef_or;
    private Vector3 velocity;
    public Transform target;
    public int EnemieHealth = 100;
    public Slider EnemieHealthSlider;
    public Slider DamageAnimSlider;
    public Image SliderColor;
    public GameObject[] heartcount;
    public bool DoDamage = false;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Ef_or = gameObject.GetComponentInChildren<EnemieFollowOnRange>();
    }

    // Update is called once per frame
    void Update () {
        if(DoDamage == false)
        {
            DamageAnimSlider.gameObject.SetActive(false);
            DamageAnimSlider.value = EnemieHealthSlider.value;
        }
        heartcount = GameObject.FindGameObjectsWithTag("heart");
        if(heartcount.Length > 1)
        {
            Destroy(heartcount[1]);
            if (heartcount.Length > 2)
            {
                Destroy(heartcount[2]);
                if (heartcount.Length > 3)
                {
                    Destroy(heartcount[3]);
                }  
            }
        }
        if (DamageAnimSlider.value > EnemieHealthSlider.value)
        {
            DamageAnimSlider.value -= 0.3f;
        }
        if (DamageAnimSlider.value <= EnemieHealthSlider.value)
        {
            DamageAnimSlider.value = EnemieHealthSlider.value;
        }
        if ((Ef_or.IsInRange == true) && (GameObject.Find("ChicaSexy").GetComponent<PlayerController_tp>().dead == false))
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, 200 * Time.deltaTime);
            gameObject.GetComponent<Animator>().SetBool("OnRange", true);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("OnRange", false);
        }
        EnemieHealthSlider.value = EnemieHealth;
        if (EnemieHealthSlider.value >= 50.0f)
        {
            SliderColor.color = new Color(0, 255, 0);
        }
        if ((EnemieHealthSlider.value > 25.0f) && (EnemieHealthSlider.value <= 50.0f))
        {
            SliderColor.color = new Color(255, 255, 0);
        }
        if (EnemieHealthSlider.value <= 25.0f)
        {
            SliderColor.color = new Color(1, 0.25f, 0.25f);
        }
    }

    public void DoDamageSliderAnim()
    {
        if (DoDamage == true)
        {
            DamageAnimSlider.gameObject.SetActive(true);
            DamageAnimSlider.value -= 1.60f;

            if (DamageAnimSlider.value == EnemieHealthSlider.value)
            {
                DamageAnimSlider.value = EnemieHealthSlider.value;
                DamageAnimSlider.gameObject.SetActive(false);
                DoDamage = false;
            }
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Laser")
        {
            Destroy(gameObject, 0.5f);
        }
    }
}
