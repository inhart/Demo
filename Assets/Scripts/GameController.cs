using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject PauseMenu;
    private bool isPaused = false;
    public bool lastscene = false;
    public bool Gas = false;
    public bool SelectACharacter = false;
    public GameObject LastSelected;
    public GameObject CurrentSelected;
    public static GameController gc;
    public GameObject circle;
    

    private void Awake()
    {
        if(gc == null)
        {
            gc = this;

        }else if (gc != this)
        {
            Destroy(this);
        }
        circle = GameObject.Find("CircleSelector");
    }
    // Update is called once per frame
    void Update()
    {
       if(SelectACharacter == false)
        {
            GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find(null));
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

        if(Input.GetButton("Rueda"))
        {
            SelectACharacter = true;
            circle.GetComponent<Animator>().SetBool("OpenCircle", true);
            GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find(null));
            var rAngle = Mathf.Atan2(Input.GetAxis("Vertical2"), Input.GetAxis("Horizontal2"));
            float aAngle = 0;
            if (rAngle >= 0)
            {
                aAngle = Mathf.Rad2Deg * rAngle;
              
            }else if (rAngle < 0)
            {
                aAngle = 360 + Mathf.Rad2Deg * rAngle ;
            }
            if((aAngle == 0) && (Input.GetAxis("Vertical2") == 0) && (Input.GetAxis("Horizontal2") == 0))
            {
                SeleccionPersonaje.sp.SeleccionPers(SeleccionPersonaje.sp.selectedPlayer);
                return;
            }
            if ((aAngle > 300 || aAngle <=90) && SelectACharacter)
            {
                GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("CircleBottomLine"));
            }
            if ((aAngle >= 180 && aAngle < 300) && SelectACharacter)
            {
                GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("CircleRightLine"));
            }
            if ((aAngle > 80 && aAngle < 180) && SelectACharacter)
            {
                GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(GameObject.Find("CircleLeftLine"));
            }
        }
        else
        {
            SelectACharacter = false;
            if(circle.activeInHierarchy == true)
            {
                circle.GetComponent<Animator>().SetBool("OpenCircle", false);
            }
            //GameObject.Find("ChicaSexy").GetComponent<PlayerController>().enabled = true;
            //GameObject.Find("ChicaSexy").GetComponent<PowerController>().enabled = true;
            //GameObject.Find("ChicaSexy").GetComponent<ShootController>().enabled = true;
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
       // PauseMenu.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level01");
        isPaused = false;
        PauseMenu.SetActive(isPaused);
       // PlayerController.playerLifes = 10;
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