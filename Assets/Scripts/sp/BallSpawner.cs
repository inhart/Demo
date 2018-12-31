using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{

    public static BallSpawner bs;

    public GameObject[] ballsPrefab;

    public GameObject[] HexagonsPrefab;

    public GameObject ball = null;

    public bool free;

    int dificulty = 0;

    float timeSpawn = 5;

    private void Awake()
    {
        if (bs == null)
        {
            bs = this;
        }
        else if (bs != this)
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {

        if (ball != null && ball.transform.position.y <= 4f && !free)
        {
            ball.GetComponent<Ball>().StartForce(ball);
            free = true;
            BallManager.bm.balls.Add(ball);
            ball.gameObject.tag = "ball";
            if (ball.GetComponent<Ball>().sprites.Length > 0)
            {
                ball.name = ball.GetComponent<SpriteRenderer>().name;
            }

            ball = null;

        }
    }

    public void NewBall()
    {
        if (!FreezeManager.fm.freeze)
        {
            free = false;
            ball = Instantiate(ballsPrefab[Random.Range(0, ballsPrefab.Length - 1)],
                new Vector2(AleaPos(), transform.position.y), Quaternion.identity);
            BallManager.bm.balls.Add(ball);
            ball.gameObject.tag = "Untagged";
            StartCoroutine(MoveDown());

        }
    }

    float AleaPos()
    {
        return (Random.Range(-7f, 7f));
    }

    public void IncreaseDificulty()
    {
        dificulty++;

        if(dificulty >= 10)
        {
            timeSpawn = 3;
        }
        else
        {
            timeSpawn = Random.Range(3f, 5f);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Untagged")
        {
            free = false;
        }
    }

    public IEnumerator MoveDown()
    {

        if (ball != null)
        {
            while (!free)
            {
                if (FreezeManager.fm.freeze)
                {
                    break;
                }
                ball.transform.position = new Vector2(ball.transform.position.x, ball.transform.position.y - 0.5f);
                yield return new WaitForSeconds(1);
            }

            yield return new WaitForSeconds(timeSpawn);
            if (free)
            {
                NewBall();
            }
        }
    }
}
