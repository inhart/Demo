
using UnityEngine;

public class Ball : MonoBehaviour {

    public GameObject nextBall;
    Rigidbody2D rb;
    public bool right;
    Vector2 currentVelocity;
    public GameObject powerUp;
    public GameObject specialBall;

    public Sprite[] sprites;
    SpriteRenderer sr;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnBecameInvisible()
    {
        if (GameManager.gm.gamemode == GameMode.TOUR)
        {
            if (BallManager.bm.balls.Contains(gameObject))
            {
                BallManager.bm.balls.Remove(gameObject);
            }
                     
            Destroy(gameObject);
        }
    }

    public void Split()
    {
        GameManager.gm.PanicProgress();
        if (nextBall != null)
        {
            if (GameManager.gm.gamemode == GameMode.TOUR)
            {
                InstantiatePrize();
            }

            GameObject ball1 = Instantiate(nextBall, rb.position + Vector2.right / 4, Quaternion.identity);
            ball1.GetComponent<Ball>().right = true;

            GameObject ball2 = null;

            if (specialBall == null || GameManager.gm.gamemode == GameMode.TOUR)
            {

                ball2 = Instantiate(nextBall, rb.position + Vector2.left / 4, Quaternion.identity);
            }
            else
            {
                    ball2 = Instantiate(specialBall, rb.position + Vector2.left / 4, Quaternion.identity);
                
            }
            ball2.GetComponent<Ball>().right = false;
              
            if (!FreezeManager.fm.freeze)
            {
                ball1.GetComponent<Rigidbody2D>().isKinematic = false;
                ball1.GetComponent<Rigidbody2D>().AddForce(new Vector2(2, 5), ForceMode2D.Impulse);
              

                ball2.GetComponent<Rigidbody2D>().isKinematic = false;
                ball2.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2, 5), ForceMode2D.Impulse);
               
            }
            else
            {
                ball1.GetComponent<Ball>().currentVelocity = new Vector2(2, 5);
                ball2.GetComponent<Ball>().currentVelocity = new Vector2(-2, 5);
            }

            if (!BallManager.bm.spliting)
            {
                BallManager.bm.DestroyBall(gameObject, ball1, ball2);
            }
        }
        else
        {
            BallManager.bm.LastBall(gameObject);

            if (name.Contains("Special"))
            {
                FreezeManager.fm.StartFreeze(1.5f);
            }
        }

        int score = Random.Range(100, 301);
        PopUpManager.pop.InstanciatePopUpText(gameObject.transform.position,score);
        ScoreManager.sm.UpdateScore(score);
        GameManager.gm.UpdateBallsDestroyed();
    }
    public void StartForce(GameObject balls)
    {

        balls.GetComponent<Rigidbody2D>().isKinematic = false;

       
            if (right)
            {
                balls.GetComponent<Rigidbody2D>().AddForce(new Vector2(2, 0), ForceMode2D.Impulse);
            }
            else
            {
                balls.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2, 0), ForceMode2D.Impulse);
            }
        

    }
    public void FreezeBalls(params GameObject[] ball)
    {
        foreach(GameObject item in ball)
        {
            if(item != null)
            {
                currentVelocity = item.GetComponent<Rigidbody2D>().velocity;
                item.GetComponent<Rigidbody2D>().isKinematic = true;
                item.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
    }
    public void UnFreezeBalls(params GameObject[] ball)
    {
        foreach (GameObject item in ball)
        {
            if (item != null)
            {
                item.GetComponent<Rigidbody2D>().isKinematic = false;
                item.GetComponent<Rigidbody2D>().AddForce(currentVelocity,ForceMode2D.Impulse);
               
            }
        }
    }

    public void SlowBall()
    {
        rb.velocity /= 1.4f; //rb.velocity = rb.verlocity/4
        rb.gravityScale = 0.5f;
    }
    public void NormalSpeedBall()
    {
       if(rb.velocity.x < 0)
        {
            rb.velocity = new Vector2(-2, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(2, rb.velocity.y);
        }
        rb.gravityScale = 1;
    }
    void InstantiatePrize()
    {
        int aleatory = GameManager.gm.AleatoryNumber();

        if (aleatory == 1)
        {
            Instantiate(powerUp, transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "lurra" && 
            (gameObject.name.Contains("DestroyBall") ||
            gameObject.name.Contains("StopBall")))
        {
            if(sr.sprite == sprites[0])
            {
                sr.sprite = sprites[1];
              
            }
            else
            {
                sr.sprite = sprites[0];
             
            }
            gameObject.name = sr.sprite.name;
        }
   
        
    }
}
