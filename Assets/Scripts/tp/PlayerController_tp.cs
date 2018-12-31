using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController_tp : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed_x;
    public float jump_speed;
    public bool Inground = false;
    GameObject ClosestPlatform;
    public bool dead = false;

    public static int playerHealth = 100;

    public static int playerLifes = 10;
    public Slider playerHealthSlider;
    public Image SliderColor;
    public Slider DamageAnimSlider;

    public GameObject PlayerPart1;
    public GameObject PlayerPart2;
    public GameObject PlayerPart3;
    public GameObject PlayerPart4;
    public GameObject PlayerPart5;
    public GameObject PlayerPart6;

    public bool IsFlipped = false;

    public GameObject HurtImage;
    public bool DoDamage = false;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        playerHealthSlider.value = playerHealth;
        if (playerHealthSlider.value >= 50.0f)
        {
            SliderColor.color = new Color(0, 255, 0);
        }
        if ((playerHealthSlider.value > 25.0f) && (playerHealthSlider.value <= 50.0f))
        {
            SliderColor.color = new Color(255, 255, 0);
        }
        if (playerHealthSlider.value <= 25.0f)
        {
            SliderColor.color = new Color(1, 0.25f, 0.25f);
        }
        if (rb.velocity.magnitude == 0)
        {
            gameObject.GetComponent<Animator>().SetBool("Idle", true);
            gameObject.GetComponent<Animator>().SetBool("Running", false);
        }
        if (rb.velocity.magnitude > 0)
        {
            gameObject.GetComponent<Animator>().SetBool("Running", true);
            gameObject.GetComponent<Animator>().SetBool("Idle", false);
        }
        /*float valueX = Input.GetAxis("Horizontal");
        if(valueX > 0)
        {
            rb.AddForce(new Vector2(valueX * speed_x, 0));
            PlayerPart1.GetComponent<SpriteRenderer>().flipX = false;
            PlayerPart2.GetComponent<SpriteRenderer>().flipX = false;
            PlayerPart3.GetComponent<SpriteRenderer>().flipX = false;
            PlayerPart4.GetComponent<SpriteRenderer>().flipX = false;
            PlayerPart5.GetComponent<SpriteRenderer>().flipX = false;
            PlayerPart6.GetComponent<SpriteRenderer>().flipX = false;
            IsFlipped = false;
            gameObject.GetComponent<Animator>().SetBool("Flipped", false);
        }
        if (valueX < 0)
        {
            rb.AddForce(new Vector2(valueX * speed_x, 0));
            PlayerPart1.GetComponent<SpriteRenderer>().flipX = true;
            PlayerPart2.GetComponent<SpriteRenderer>().flipX = true;
            PlayerPart3.GetComponent<SpriteRenderer>().flipX = true;
            PlayerPart4.GetComponent<SpriteRenderer>().flipX = true;
            PlayerPart5.GetComponent<SpriteRenderer>().flipX = true;
            PlayerPart6.GetComponent<SpriteRenderer>().flipX = true;
            IsFlipped = true;
            gameObject.GetComponent<Animator>().SetBool("Flipped", true);
        }
        */
        if (Input.GetKey(KeyCode.D))
        {
            //transform.Translate(new Vector2(speed_x, 0));
            rb.AddForce(new Vector2(speed_x, 0));
            PlayerPart1.GetComponent<SpriteRenderer>().flipX = false;
            PlayerPart2.GetComponent<SpriteRenderer>().flipX = false;
            PlayerPart3.GetComponent<SpriteRenderer>().flipX = false;
            PlayerPart4.GetComponent<SpriteRenderer>().flipX = false;
            PlayerPart5.GetComponent<SpriteRenderer>().flipX = false;
            PlayerPart6.GetComponent<SpriteRenderer>().flipX = false;
            IsFlipped = false;
            gameObject.GetComponent<Animator>().SetBool("Flipped", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //transform.Translate(new Vector2(-speed_x, 0));
            rb.AddForce(new Vector2(-speed_x, 0));
            PlayerPart1.GetComponent<SpriteRenderer>().flipX = true;
            PlayerPart2.GetComponent<SpriteRenderer>().flipX = true;
            PlayerPart3.GetComponent<SpriteRenderer>().flipX = true;
            PlayerPart4.GetComponent<SpriteRenderer>().flipX = true;
            PlayerPart5.GetComponent<SpriteRenderer>().flipX = true;
            PlayerPart6.GetComponent<SpriteRenderer>().flipX = true;
            IsFlipped = true;
            gameObject.GetComponent<Animator>().SetBool("Flipped", true);
        }
        if ((Input.GetKeyDown(KeyCode.Space)) || (Input.GetButtonDown("X")) && (Inground == true))
        {
            rb.AddForce(new Vector2(0, jump_speed));
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (Inground == true)
            {
                ClosestPlatform.GetComponent<BoxCollider2D>().isTrigger = true;
            }
        }
        if ((playerHealth <= 0) && (playerLifes > 0))
        {
            playerLifes -= 1;
            playerHealth = 100;
            DamageAnimSlider.gameObject.SetActive(false);
            DamageAnimSlider.value = 100;
            gameObject.transform.position = new Vector3(100, 1100);
        }
        if (playerLifes == 0)
        {
            dead = true;
        }
        if (dead == true)
        {
            GameObject.Find("YouAreDead").GetComponent<Animation>().Play();
            Destroy(gameObject);
        }
        if (playerLifes > 5)
        {
            GameObject.Find("gameControl").GetComponent<UIController>().Lifes_text.gameObject.SetActive(true);
            GameObject.Find("gameControl").GetComponent<UIController>().Heart5.SetActive(false);
            GameObject.Find("gameControl").GetComponent<UIController>().Heart4.SetActive(false);
            GameObject.Find("gameControl").GetComponent<UIController>().Heart3.SetActive(false);
            GameObject.Find("gameControl").GetComponent<UIController>().Heart2.SetActive(false);
            GameObject.Find("gameControl").GetComponent<UIController>().Heart1.SetActive(true);
        }
        if (playerLifes == 5)
        {
            GameObject.Find("gameControl").GetComponent<UIController>().Lifes_text.gameObject.SetActive(false);
            GameObject.Find("gameControl").GetComponent<UIController>().Heart5.SetActive(true);
            GameObject.Find("gameControl").GetComponent<UIController>().Heart4.SetActive(true);
            GameObject.Find("gameControl").GetComponent<UIController>().Heart3.SetActive(true);
            GameObject.Find("gameControl").GetComponent<UIController>().Heart2.SetActive(true);
            GameObject.Find("gameControl").GetComponent<UIController>().Heart1.SetActive(true);
        }
        if (playerLifes == 4)
        {
            GameObject.Find("gameControl").GetComponent<UIController>().Lifes_text.gameObject.SetActive(false);
            GameObject.Find("gameControl").GetComponent<UIController>().Heart5.SetActive(false);
            GameObject.Find("gameControl").GetComponent<UIController>().Heart4.SetActive(true);
            GameObject.Find("gameControl").GetComponent<UIController>().Heart3.SetActive(true);
            GameObject.Find("gameControl").GetComponent<UIController>().Heart2.SetActive(true);
            GameObject.Find("gameControl").GetComponent<UIController>().Heart1.SetActive(true);
        }
        if (playerLifes == 3)
        {
            GameObject.Find("gameControl").GetComponent<UIController>().Lifes_text.gameObject.SetActive(false);
            GameObject.Find("gameControl").GetComponent<UIController>().Heart5.SetActive(false);
            GameObject.Find("gameControl").GetComponent<UIController>().Heart4.SetActive(false);
            GameObject.Find("gameControl").GetComponent<UIController>().Heart3.SetActive(true);
            GameObject.Find("gameControl").GetComponent<UIController>().Heart2.SetActive(true);
            GameObject.Find("gameControl").GetComponent<UIController>().Heart1.SetActive(true);
        }
        if (playerLifes == 2)
        {
            GameObject.Find("gameControl").GetComponent<UIController>().Lifes_text.gameObject.SetActive(false);
            GameObject.Find("gameControl").GetComponent<UIController>().Heart5.SetActive(false);
            GameObject.Find("gameControl").GetComponent<UIController>().Heart4.SetActive(false);
            GameObject.Find("gameControl").GetComponent<UIController>().Heart3.SetActive(false);
            GameObject.Find("gameControl").GetComponent<UIController>().Heart2.SetActive(true);
            GameObject.Find("gameControl").GetComponent<UIController>().Heart1.SetActive(true);
        }
        if (playerLifes == 1)
        {
            GameObject.Find("gameControl").GetComponent<UIController>().Lifes_text.gameObject.SetActive(false);
            GameObject.Find("gameControl").GetComponent<UIController>().Heart5.SetActive(false);
            GameObject.Find("gameControl").GetComponent<UIController>().Heart4.SetActive(false);
            GameObject.Find("gameControl").GetComponent<UIController>().Heart3.SetActive(false);
            GameObject.Find("gameControl").GetComponent<UIController>().Heart2.SetActive(false);
            GameObject.Find("gameControl").GetComponent<UIController>().Heart1.SetActive(true);
        }
        if (playerLifes == 0)
        {
            GameObject.Find("gameControl").GetComponent<UIController>().Heart1.SetActive(false);
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemie")
        {
            HurtImage.SetActive(true);
            GameObject.Find("AudioContainer2").GetComponent<AudioSource>().Play();
            GameObject.Find("HurtImage").GetComponent<Animation>().Play();
        }
        if (col.gameObject.tag == "Hitler")
        {
            HurtImage.SetActive(true);
            GameObject.Find("AudioContainer2").GetComponent<AudioSource>().Play();
            GameObject.Find("HurtImage").GetComponent<Animation>().Play();
        }

        if (col.gameObject.tag == "heart")
        {
            playerLifes += 1;
            Destroy(col.gameObject);
        }

    }
    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Suelo")
        {
            Inground = true;
            ClosestPlatform = col.gameObject;
        }
        if (col.gameObject.tag == "Enemie")
        {
            HurtImage.SetActive(true);
            playerHealth -= 1;
            DoDamage = true;
            DoDamageSliderAnim();
            GameObject.Find("HurtImage").GetComponent<Animation>().Play();
        }
        if (col.gameObject.tag == "Hitler")
        {
            HurtImage.SetActive(true);
            playerHealth -= 1;
            DoDamage = true;
            DoDamageSliderAnim();
            GameObject.Find("HurtImage").GetComponent<Animation>().Play();
        }
        if (col.gameObject.tag == "Enemie")
        {
            Inground = true;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Suelo")
        {
            Inground = false;
            ClosestPlatform = null;
        }
        if (col.gameObject.tag == "Enemie")
        {
            HurtImage.SetActive(false);
            DamageAnimSlider.gameObject.SetActive(false);
        }
        if (col.gameObject.tag == "Hitler")
        {
            HurtImage.SetActive(false);
            DamageAnimSlider.gameObject.SetActive(false);
        }
    }

    void DoDamageSliderAnim()
    {
        if (DoDamage == true)
        {
            DamageAnimSlider.gameObject.SetActive(true);
            DamageAnimSlider.value -= 0.90f;

            if (DamageAnimSlider.value == playerHealthSlider.value)
            {
                DamageAnimSlider.value = playerHealthSlider.value;
                DamageAnimSlider.gameObject.SetActive(false);
                DoDamage = false;
            }
        }

    }
}