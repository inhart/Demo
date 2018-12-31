
using UnityEngine;

public class Hexagon : MonoBehaviour {

    public GameObject nextHexagon;
    Rigidbody2D rb;
    public bool right;

    public float forceX = 1;
    public float forceY = 1;

    float currentforceX;
    float currentforceY;

    float rotSpeed;




    public GameObject powerUp;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        rb.velocity = Vector2.zero;
    }
    private void OnBecameInvisible()
    {
        if (GameManager.gm.gamemode == GameMode.TOUR)
        {
            if (HexagonManager.hm.hexagons.Contains(gameObject))
            {
                HexagonManager.hm.hexagons.Remove(gameObject);
            }

            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (GameManager.inGame)
        {
            rotSpeed = 250 * Time.deltaTime;
            transform.Rotate(0, 0, rotSpeed);
            rb.velocity = new Vector2(forceX, forceY);
        }
        else
        {
            rotSpeed = 0;
            rb.velocity = Vector2.zero;
        }
    }
    public void Split()
    {
        if (nextHexagon != null)
        {
            GameManager.gm.PanicProgress();
            if (GameManager.gm.gamemode == GameMode.TOUR)
            {
                InstantiatePrize();
            }
            GameObject hex1 = Instantiate(nextHexagon, rb.position + Vector2.right / 4, Quaternion.identity);
            hex1.GetComponent<Hexagon>().right = true;

            GameObject hex2 = Instantiate(nextHexagon, rb.position + Vector2.left / 4, Quaternion.identity);
            hex2.GetComponent<Hexagon>().right = false;

            if (!FreezeManager.fm.freeze)
            {
                hex1.GetComponent<Hexagon>().forceX = forceX;
                hex1.GetComponent<Hexagon>().forceY = -forceY;
                hex2.GetComponent<Hexagon>().forceX = -forceX;
                hex2.GetComponent<Hexagon>().forceY = -forceY;

            }
            else
            {
                hex1.GetComponent<Hexagon>().currentforceX = forceX;
                hex1.GetComponent<Hexagon>().currentforceY = -forceY;

                hex2.GetComponent<Hexagon>().currentforceX = -forceX;
                hex2.GetComponent<Hexagon>().currentforceY = -forceY;
            }

            if (!HexagonManager.hm.spliting)
            {
                HexagonManager.hm.DestroyHexagon(gameObject, hex1, hex2);
            }
        }
        else
        {
            HexagonManager.hm.LastHexagon(gameObject);
        }

        int score = Random.Range(300, 601);
        PopUpManager.pop.InstanciatePopUpText(gameObject.transform.position, score);
        ScoreManager.sm.UpdateScore(score);
        GameManager.gm.UpdateBallsDestroyed();
    }
    public void StartForce(GameObject hex)
    {
             
        if (right)
        {
           
           hex.GetComponent<Hexagon>().forceX = forceX;
        }
        else
        {
            hex.GetComponent<Hexagon>().forceX = -forceX;
        }

        hex.GetComponent<Hexagon>().forceY = forceY;
    }
    public void FreezeHexagon(params GameObject[] hexagons)
    {
        foreach (GameObject item in hexagons)
        {
            if (item != null)
            {
                currentforceX = item.GetComponent<Hexagon>().forceX;
                currentforceY = item.GetComponent<Hexagon>().forceY;

                item.GetComponent<Hexagon>().forceX = 0;
                item.GetComponent<Hexagon>().forceY = 0;
                item.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
    }
    public void UnFreezeHexagon(params GameObject[] hexagons)
    {
        foreach (GameObject item in hexagons)
        {
            if (item != null)
            {
                 item.GetComponent<Hexagon>().forceX = currentforceX;
                 item.GetComponent<Hexagon>().forceY = currentforceY;
                item.GetComponent<Rigidbody2D>().velocity = new Vector2(currentforceX,currentforceY);


            }
        }
    }

    public void SlowHexagon()
    {
        if (rb.velocity.x < 0)
        {
            forceX = -1;
        }
        else
        {
            forceX = 1;
        }
        if (rb.velocity.y < 0)
        {
            forceY = -1;
        }
        else
        {
            forceY = 1;
        }

        

    }
    public void NormalSpeedHexagon()
    {
        if (rb.velocity.x < 0)
        {
            forceX = -2;
        }
        else
        {
            forceX = 2;
        }
        if (rb.velocity.y < 0)
        {
            forceY = -2;
        }
        else
        {
            forceY = 2;
        }
        rb.velocity = new Vector2(forceX, forceY);
    }
    void InstantiatePrize()
    {
        int aleatory = GameManager.gm.AleatoryNumber();

        if (aleatory == 1)
        {
            Instantiate(powerUp, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "lurra" || other.gameObject.tag == "zapaia")
        {
            forceY *= -1;
        }
        if (other.gameObject.tag == "ezkerra" || other.gameObject.tag == "eskubi")
        {
            forceX *= -1;
        }
    }
}