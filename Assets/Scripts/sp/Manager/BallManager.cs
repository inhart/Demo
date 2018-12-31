﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {
    public static BallManager bm;
    public List<GameObject> balls = new List<GameObject>();
    public bool spliting;
    
    // Use this for initialization
    private void Awake()
    {
        if (bm == null)
        {
            bm = this;
        }
        if (bm != this)
        {
            Destroy(gameObject);
        }
       
    }

    void Start () {
        balls.AddRange(GameObject.FindGameObjectsWithTag("ball"));
        
	}

    private void Update()
    {
        ReloadList();
    }

    public void LoseGame()
    {
        foreach(GameObject item in balls)
        {
            if (item != null)
            {
                item.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                item.GetComponent<Rigidbody2D>().isKinematic = true;
            }
        }
        
    }
	
	
    public void StartGame()
    {
        foreach(GameObject item in balls)
        {
            if (balls.IndexOf(item) % 2 == 0)
            {
                item.GetComponent<Ball>().right = true;
            }
            else
            {
                item.GetComponent<Ball>().right = false;
            }
            item.GetComponent<Ball>().StartForce(item);
        }
    }

    public void DestroyBall(GameObject ball, GameObject ball1, GameObject ball2)
    {
        
        balls.Remove(ball);
        Destroy(ball);
        balls.Add(ball1);
        balls.Add(ball2);
    }
    public void LastBall(GameObject ball) {
        balls.Remove(ball);
        Destroy(ball);
       
    }
    public void Dinamite(int maxNumBalls)
    {
        StartCoroutine(DinamitaB(maxNumBalls));
    }

    public void SlowTime()
    {
        StartCoroutine(TimeSlow());
    }
    List<GameObject> FindBalls(int typeOfBall)
    {
        List<GameObject> ballsToDestroy = new List<GameObject>();
        for(int i =0; i < balls.Count; i++)
        {
            if (balls[i].GetComponent<Ball>().name.Contains(typeOfBall.ToString()) && balls[i] != null)
            {
                ballsToDestroy.Add(balls[i]);
            }
        }
        return ballsToDestroy;
    }

    void ReloadList()
    {
        balls.Clear();

        balls.AddRange(GameObject.FindGameObjectsWithTag("ball"));
    }

    public IEnumerator DinamitaB(int maxNumberBalls)
    {
        ReloadList();
        spliting = true;

        int numberToFind = 1;
        while (numberToFind < maxNumberBalls)
        {


            foreach (GameObject item in FindBalls(numberToFind))
            {
                item.GetComponent<Ball>().Split();
                Destroy(item);
            }

            yield return new WaitForSeconds(.5f);
            ReloadList();

            numberToFind++;
        }
        spliting = false;
    }

    public IEnumerator TimeSlow()
    {
        float time = 0;
        

        foreach(GameObject item in balls)
        {
            if(item != null)
            {
                item.GetComponent<Ball>().SlowBall();
            }
        }

        while(time < 3)
        {
            time += Time.deltaTime;
            yield return null;
        }

        foreach (GameObject item in balls)
        {
            if (item != null)
            {
                item.GetComponent<Ball>().NormalSpeedBall();
            }
        }
       
    }

   
}
