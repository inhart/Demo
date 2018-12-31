using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{


    float speedX = 4f;
    public float speedY = 4f;
    float movementX = 0f;
    float movementY = 0f;
    float maxClimbY = 0;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sr;
    float newY;
    float newX;
    public bool climb;
    float defaultPosY;
    public bool inGround;
    public bool isUp;
    public bool eskubiHorma;
    public bool ezkerHorma;
    LifeManager lm;
    public GameObject shield;
    public bool blink;
    // Use this for initialization
    private void Awake()
    {
        lm = FindObjectOfType<LifeManager>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        defaultPosY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.inGame)
        {
            movementX = Input.GetAxisRaw("Horizontal") * speedX;
            movementY = Input.GetAxisRaw("Vertical") * speedY;

            animator.SetInteger("velX", Mathf.RoundToInt(movementX));
            animator.SetInteger("velY", Mathf.RoundToInt(movementY));

            if (movementX < 0)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }

            if (GameManager.gm.time < 0)
            {
                StartCoroutine("Lose");
            }
        }

    }
    private void FixedUpdate()
    {
       
        if (GameManager.inGame)
        {
            if (GameManager.gm.gamemode == GameMode.TOUR)
            {
                if (transform.position.y < defaultPosY)
                {
                    transform.position = new Vector2(transform.position.x, defaultPosY);
                }
            }
            if (ezkerHorma == true)
            {
                if (Input.GetAxis("Horizontal")<0)
                {
                    speedX = 0;
                }
                else if (Input.GetAxis("Horizontal") > 0)
                {
                    speedX = 4;
                }
            }
            if (eskubiHorma == true)
            {
                if (Input.GetAxis("Horizontal")>0)
                {
                    speedX = 0;
                }
                else if (Input.GetAxis("Horizontal")<0)
                {
                    speedX = 4;
                }
            }


            if (transform.position.y >= maxClimbY)
            {
                isUp = true;
            }
            else
            {
                isUp = false;
            }

            if (climb)
            {
                if ((Input.GetKey(KeyCode.UpArrow) && !isUp) || (Input.GetKey(KeyCode.DownArrow) && !inGround))
                {
                    speedY = 4;
                }
                else
                {
                    speedY = 0;
                }
            }
            else
            {
                speedY = 0;
            }
            if (movementX != 0)
            {
                rb.MovePosition(rb.position + Vector2.right * movementX * Time.fixedDeltaTime);
            }
            else if ((transform.position.y >= defaultPosY && climb && !isUp) || 
                (isUp && (Input.GetAxis("Vertical") < 0)))

            {
                rb.MovePosition(rb.position + Vector2.up * movementY * Time.fixedDeltaTime);
            }
        }

        if(!inGround && !climb)
        {
            transform.position += new Vector3(movementX / 5, -1) * Time.deltaTime * 3;
        }
        //  newX = Mathf.Clamp(transform.position.x, -8, 8);
        //  transform.position = new Vector2(newX, transform.position.y);
    }
    public void Win()
    {
        shield.SetActive(false);
        animator.SetBool("win", true);
    }
    private void OnBecameInvisible()
    {
        Invoke("ReloadLevel", 0.5f);
        if (lm.lifes <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
    void ReloadLevel()
    {
        lm.SubstractLifes();

        lm.RestartLifesDoll();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.inGame && !FreezeManager.fm.freeze)
        {

            if (collision.gameObject.tag == "ball" || collision.gameObject.tag == "Hexagon")
            {
                if (shield.activeInHierarchy)
                {
                    shield.SetActive(false);

                    StartCoroutine(Blinking());
                }
                else
                {
                    if (!blink)
                    {
                        StartCoroutine(Lose());
                    }
                }

            }

            if (collision.gameObject.tag == "leader")
            {
                if (!isUp)
                {
                    maxClimbY = transform.position.y + collision.GetComponent<BoxCollider2D>().size.y - 0.1f;
                }

            }
           
        if(collision.gameObject.tag == "platform"&&
                transform.position.y< collision.gameObject.transform.position.y &&
                inGround)
            {
                transform.position = new Vector2(transform.position.x,
                    transform.position.y + 0.4f);
            }
        }
        if (!GameManager.inGame && (collision.gameObject.tag == "ezkerra" || collision.gameObject.tag == "eskubi"))
        {

            sr.flipX = !sr.flipX;
            rb.velocity /= 3;
            rb.velocity *= -1;
            rb.AddForce(Vector3.up * 5, ForceMode2D.Impulse);
        }


    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "ezkerra")
        {
            ezkerHorma = true;
        }
        else if (other.gameObject.tag == "eskubi")
        {
            eskubiHorma = true;
        }

        if (other.gameObject.tag == "leader")
        {
            climb = true;
        }

        if (other.gameObject.tag == "lurra" || other.gameObject.tag == "platform" &&
             transform.position.y> other.gameObject.transform.position.y)
        {
            inGround = true;
        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ezkerra")
        {
            ezkerHorma = false;

        }
        else if (collision.gameObject.tag == "eskubi")
        {
            eskubiHorma = false;
        }
        if (collision.gameObject.tag == "leader")
        {
            climb = false;
        }
        if (collision.gameObject.tag == "lurra" || collision.gameObject.tag == "platform")
        {
            inGround = false;
        }
    }

    public IEnumerator Blinking()
    {
        blink = true;
        for (int i = 0; i < 8; i++)
        {
            if (blink && GameManager.inGame)
            {
                sr.color = new Color(1, 1, 1, 0);
                yield return new WaitForSeconds(0.2f);
                sr.color = new Color(1, 1, 1, 1);
                yield return new WaitForSeconds(0.2f);
            }
            else
            {
                break;
            }
        }
        blink = false;
    }

    public IEnumerator Lose()
    {
        GameManager.inGame = false;
        animator.SetBool("lose", true);
        BallManager.bm.LoseGame();
        HexagonManager.hm.LoseGame();
        lm.LifeLose();

        yield return new WaitForSeconds(1);

        rb.isKinematic = false;

        if (transform.position.x <= 0)
        {
            rb.AddForce(new Vector2(-10, 10), ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(new Vector2(10, 10), ForceMode2D.Impulse);
        }

    }
}
