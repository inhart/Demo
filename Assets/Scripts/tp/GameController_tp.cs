using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameController_tp : MonoBehaviour
{

    public static int Score = 0;
    GameObject[] EnemieCount;

    public GameObject Gorro;
    public GameObject Mask;
    public GameObject Etiketa;
    public GameObject PauseMenu;
    public GameObject Hitler;
    private bool isPaused = false;
    public bool lastscene = false;
    public GameObject nasi1;
    public GameObject nasi2;
    public GameObject nasi3;
    public GameObject nasi4;
    public GameObject nasi5;
    public GameObject nasi6;
    public GameObject nasi7;
    public GameObject nasi8;
    public GameObject nasi9;
    public bool Gas = false;
    public bool SelectACharacter = false;
    public GameObject LastSelected;
    public GameObject CurrentSelected;
    public GameObject TumblePop;
    public GameObject SnowBros;
    public GameObject Pang;

    // Use this for initialization
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level05")
        {
            Debug.Log("xd");
            lastscene = true;
            GameObject.Find("Main Camera").GetComponent<UB.D2FogsPE>().enabled = false;
            Gorro.SetActive(false);
        }
        CurrentSelected = GameObject.Find("ChicaSexy");
        TumblePop.SetActive(true);
        SnowBros.SetActive(false);
        Pang.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        EnemieCount = GameObject.FindGameObjectsWithTag("Enemie");

        if (EnemieCount.Length == 0)
        {
            if (SceneManager.GetActiveScene().name == "Level01")
            {
                SceneManager.LoadScene("Level02");
            }
            if (SceneManager.GetActiveScene().name == "Level02")
            {
                SceneManager.LoadScene("Level03");
            }
            if (SceneManager.GetActiveScene().name == "Level03")
            {
                SceneManager.LoadScene("Level04");
            }
            if (SceneManager.GetActiveScene().name == "Level04")
            {
                SceneManager.LoadScene("Level05");
            }
            if (SceneManager.GetActiveScene().name == "Level05")
            {
                nasi1.SetActive(true);
                nasi2.SetActive(true);
                nasi3.SetActive(true);
                nasi4.SetActive(true);
                nasi5.SetActive(true);
                nasi6.SetActive(true);
                nasi7.SetActive(true);
                nasi8.SetActive(true);
                nasi9.SetActive(true);
                GameObject.Find("Main Camera").GetComponent<UB.D2FogsPE>().enabled = true;
                Hitler.SetActive(true);
                Gorro.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

        if (Input.GetButton("L1"))
        {
            GameObject.Find("CircleSelector").GetComponent<Animator>().SetBool("OpenCircle", true);
            GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find(null));
            SelectACharacter = true;
            GameObject.Find("ChicaSexy").GetComponent<PlayerController_tp>().enabled = false;
            GameObject.Find("ChicaSexy").GetComponent<PowerController>().enabled = false;
            GameObject.Find("ChicaSexy").GetComponent<ShootController>().enabled = false;
            if((Input.GetAxis("Horizontal") > 0) && (Input.GetAxis("Vertical") > 0))
            {
                GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("CircleRightLine"));
                LastSelected = GameObject.Find("EventSystem").GetComponent<EventSystem>().currentSelectedGameObject;
            }
            if ((Input.GetAxis("Horizontal") > 0) && (Input.GetAxis("Vertical") <= -0.3f))
            {
                GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("CircleBottomLine"));
                LastSelected = GameObject.Find("EventSystem").GetComponent<EventSystem>().currentSelectedGameObject;
            }
            if ((Input.GetAxis("Horizontal") < 0) && (Input.GetAxis("Vertical") > 0))
            {
                GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("CircleLeftLine"));
                LastSelected = GameObject.Find("EventSystem").GetComponent<EventSystem>().currentSelectedGameObject;
            }
            if ((Input.GetAxis("Horizontal") <= 0) && (Input.GetAxis("Vertical") <= -0.3f))
            {
                GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("CircleBottomLine"));
                LastSelected = GameObject.Find("EventSystem").GetComponent<EventSystem>().currentSelectedGameObject;
            }
        }
        else
        {
            GameObject.Find("CircleSelector").GetComponent<Animator>().SetBool("OpenCircle", false);
            SelectACharacter = false;
            GameObject.Find("ChicaSexy").GetComponent<PlayerController_tp>().enabled = true;
            GameObject.Find("ChicaSexy").GetComponent<PowerController>().enabled = true;
            GameObject.Find("ChicaSexy").GetComponent<ShootController>().enabled = true;
            if(LastSelected != CurrentSelected)
            {
                if(LastSelected != null)
                {
                    if (LastSelected.name == "CircleLeftLine")
                    {
                        TumblePop.SetActive(true);
                        SnowBros.SetActive(false);
                        Pang.SetActive(false);
                        TumblePop.transform.position = CurrentSelected.gameObject.transform.position;
                        TumblePop = CurrentSelected;
                    }
                    if (LastSelected.name == "CircleRightLine")
                    {
                        TumblePop.SetActive(false);
                        SnowBros.SetActive(true);
                        Pang.SetActive(false);
                        SnowBros.transform.position = CurrentSelected.gameObject.transform.position;
                        SnowBros = CurrentSelected;
                    }
                    if (LastSelected.name == "CircleBottomLine")
                    {
                        TumblePop.SetActive(false);
                        SnowBros.SetActive(false);
                        Pang.SetActive(true);
                        Pang.transform.position = CurrentSelected.gameObject.transform.position;
                        Pang = CurrentSelected;
                    }
                }
            }
        }
        if(SelectACharacter == true)
        {
            Time.timeScale -= 0.1f;
            if(Time.timeScale <= 0.3f)
            {
                Time.timeScale = 0.3f;
            }
        }
        if (SelectACharacter == false)
        {
            Time.timeScale += 0.1f;
            if (Time.timeScale >= 1f)
            {
                Time.timeScale = 1f;
            }
        }

    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        PauseMenu.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level01");
        isPaused = false;
        PauseMenu.SetActive(isPaused);
        PlayerController_tp.playerLifes = 10;
        Time.timeScale = isPaused ? 0 : 1;
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene("Menu");

    }
    public void Tolevel01()
    {
        SceneManager.LoadScene("Level01");
    }
    public void OnQuit()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    void PauseAndResume()
    {
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
        StartCoroutine(ResumeAfterNSeconds(3.0f));
    }

    float timer = 0;
    IEnumerator ResumeAfterNSeconds(float timePeriod)
    {
        yield return new WaitForEndOfFrame();
        timer += Time.unscaledDeltaTime;
        if (timer < timePeriod)
            StartCoroutine(ResumeAfterNSeconds(3.0f));
        else
        {
            Time.timeScale = 1;
            PauseMenu.SetActive(false);//Resume
            timer = 0;
        }
    }
}
