using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {
    public Sprite[] powerUpsStatic;
    public GameObject[] powerUpsAnimated;
    bool inGround;
    SpriteRenderer sr;
    LifeManager lm;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        lm = FindObjectOfType<LifeManager>();
    }

    // Use this for initialization
    void Start () {
        int aleatory = Random.Range(0, 2);
        if (aleatory == 0)
        {
            sr.sprite = powerUpsStatic[Random.Range(0, powerUpsStatic.Length)];
            gameObject.name = sr.sprite.name;
        }
        else
        {
            Instantiate(powerUpsAnimated[Random.Range(0, powerUpsAnimated.Length)], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (!inGround)
        {
            transform.position += Vector3.down * Time.deltaTime * 2;
        }
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "lurra")
        {
            inGround = true;
           Destroy(gameObject,60);

        }

        if (other.gameObject.tag == "Player")
        {



            if (gameObject.name.Equals("DoubleArrow"))
            {

                ShootManager.shm.ChangeShot(1);

            }
            else if (gameObject.name.Equals("Ancla"))
            {

                ShootManager.shm.ChangeShot(2);

            }
            else if (gameObject.name.Equals("Gun"))
            {

                ShootManager.shm.ChangeShot(3);
            }
            else if (gameObject.name.Equals("TimeStop"))
            {

                FreezeManager.fm.StartFreeze(3f);
            }
            else if (gameObject.name.Equals("TimeSlow"))
            {

                BallManager.bm.SlowTime();
                HexagonManager.hm.SlowTime();
            }
            else if (gameObject.name.Equals("Life"))
            {


                lm.AmountLifes();
            }

            Destroy(gameObject);
        }
      
    }
}
