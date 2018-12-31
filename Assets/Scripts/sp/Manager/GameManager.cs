using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameMode { PANIC,TOUR};

public class GameManager : MonoBehaviour {
    public static GameManager gm;
    public GameObject ready;
    public GameMode gamemode;

    public static bool inGame;
    Player player;
    LifeManager lm;
    Fruits fruits;
    public float time = 100;
    public Text timeTXT;
    public int ballsDestroyed = 0;
    public int fruitsTaken = 0;
    public GameObject panel;
   

     Image progressBar;

     Text levelTXT;
    public int currentLvl = 1;

    private void Awake()
    {
        if (gm == null)
        {
            gm = this;
        }
        if (gm != this)
        {
            Destroy(gameObject);
        }
        player = FindObjectOfType<Player>();
        lm = FindObjectOfType<LifeManager>();
        fruits = FindObjectOfType<Fruits>();

        if (SceneManager.GetActiveScene().name.Equals("Panic"))
        {
            gamemode = GameMode.PANIC;
            progressBar = GameObject.FindGameObjectWithTag("progress").GetComponent<Image>();
            levelTXT = GameObject.FindGameObjectWithTag("level").GetComponent<Text>();
        }
        else
        {
            gamemode = GameMode.TOUR;
        }
        

    }

    // Use this for initialization
    void Start () {
        StartCoroutine(GameStart());
        ScoreManager.sm.UpdateHiScore();
       
      
        if (gamemode == GameMode.PANIC)
        {

            progressBar.fillAmount = 0;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (gamemode == GameMode.TOUR)
        {
            if (BallManager.bm.balls.Count == 0 && HexagonManager.hm.hexagons.Count == 0)
            {
                inGame = false;
                player.Win();
                lm.LifeWin();
                panel.SetActive(true);
               
            }
            if (inGame)
            {
                time -= Time.deltaTime;
                timeTXT.text = "Denbora " + time.ToString("f0");

            }
        }
        else
        {
            if (BallManager.bm.balls.Count == 0 && HexagonManager.hm.hexagons.Count == 0 && BallSpawner.bs.free)
            {
             
                BallSpawner.bs.NewBall();
                
            }
        }
           
        
	}


    public void UpdateBallsDestroyed()
    {
        ballsDestroyed++;

        if(ballsDestroyed % Random.Range(5,18) == 0 && BallManager.bm.balls.Count > 0)
        {
            fruits.InstanciateFruit();
        } 
    }

    public void NextLevel()
    {
        lm.RestartLifesDoll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public int AleatoryNumber()
    {
        return Random.Range(0, 3);
    }

    public void PanicProgress()
    {
        if(gamemode == GameMode.PANIC)
        {
            progressBar.fillAmount += 0.1f;

            if(progressBar.fillAmount == 1)
            {
                
                progressBar.fillAmount = 0;
                currentLvl++;
                BallSpawner.bs.IncreaseDificulty();

                if (currentLvl < 10)
                {
                    levelTXT.text = "Lvl 0" + currentLvl.ToString();
                }
                else
                {
                    levelTXT.text = "Lvl " + currentLvl.ToString();
                }
                FindObjectOfType<BackgroundChange>().Background();
            }

        }
       
    }

    public IEnumerator GameStart()
    {
        yield return new WaitForSeconds(2);
        ready.SetActive(false);
        if(gamemode == GameMode.TOUR)
        {
            BallManager.bm.StartGame();
            HexagonManager.hm.StartGame();
        }
        else
        {
            BallSpawner.bs.NewBall();
        }
        
        inGame = true;
    }
}
