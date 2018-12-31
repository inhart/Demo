using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour {

    public static ShootManager shm;
    public GameObject[] Shots;
    Transform player;
    public int maxShots;
    public int numberOfShots = 0;
    public int typeOfShot; // 0-Arrow //1-Double Arrow//2-Ancla//3-laser
    Animator animator;

    

    CurrentShotImage shotImage;

    private void Awake()
    {
        if(shm == null)
        {
            shm = this;
        }
        else if(shm!=this)
        {
            Destroy(gameObject);
        }
        player = GameObject.Find("Player").transform;
      
        shotImage = FindObjectOfType<CurrentShotImage>();
    }
    // Use this for initialization
    void Start () {
        if (GameManager.gm.gamemode == GameMode.TOUR)
        {
            typeOfShot = 0;
            maxShots = 1;
        }
        else
        {
            ChangeShot(1);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeShot(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeShot(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeShot(1);
        }
        if (CanShot() && Input.GetAxis("Jump")!=0 && GameManager.inGame )
        {
            Shot();
        }
        if(numberOfShots== maxShots && GameObject.FindGameObjectsWithTag("Arrow").Length == 0 && GameObject.FindGameObjectsWithTag("Ancla").Length == 0)
        {
            numberOfShots = 0;
        }
	}
    bool CanShot()
    {
        if(numberOfShots < maxShots )
        {
            return true;
        }
        return false;
    }
    void Shot()
    {
        if (typeOfShot != 3)
        {


            Instantiate(Shots[typeOfShot], player.position, Quaternion.identity);
        }
        else
        {
            Instantiate(Shots[typeOfShot], new Vector2(player.position.x + .5f, player.position.y + 1), Quaternion.Euler(new Vector3(0,0,-5)));
            Instantiate(Shots[typeOfShot], new Vector2(player.position.x , player.position.y + 1), Quaternion.identity);
            Instantiate(Shots[typeOfShot], new Vector2(player.position.x - .5f, player.position.y + 1), Quaternion.Euler(new Vector3(0, 0, 5)));
        }
            numberOfShots++;
        
    }
    public void DestroyShot()
    {
        if(numberOfShots>0 && numberOfShots < maxShots)
        {
            numberOfShots--;
        }
        
    }
    public void ChangeShot(int type)
    {
        if(typeOfShot != type)
        {
            switch (type)
            {
                case 0:
                    maxShots = 1;
                    shotImage.CurrentShot("");
                    break;

                case 1:
                    maxShots = 2;
                    shotImage.CurrentShot("Arrow");
                    break;
                case 2:
                    maxShots = 1;
                    shotImage.CurrentShot("Ancla");
                    break;
                case 3:
                    maxShots = 15;
                    shotImage.CurrentShot("Gun");
                    break;
            }
            typeOfShot = type;
            numberOfShots = 0;
        }
    }
}
