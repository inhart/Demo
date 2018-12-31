using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject PauseMenu;
    public bool isPaused = false;
    public bool lastscene = false;

    public bool SelectACharacter = false;
    public GameObject LastSelected;
    public GameObject CurrentSelected;
    public static GameController gc;
    public GameObject circle;
    public GameObject[] circulitos;
    public EventSystem es;


    private void Awake()
    {
        if (gc == null)
        {
            gc = this;

        }
        else if (gc != this)
        {
            Destroy(this);
        }
        circle = GameObject.Find("CircleSelector");
        circulitos = GameObject.FindGameObjectsWithTag("Rueda");
        es = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
        es.SetSelectedGameObject(null);
        if ((Input.GetAxis("Rueda") != 0) && (Input.GetButton("Rueda")))
        {
            if (!SelectACharacter)
            {
                TogglePause();
            }

          


            var rAngle = Mathf.Atan2(Input.GetAxis("RightJoystickY"), Input.GetAxis("RightJoystickX"));
            float aAngle = 0;
            if (rAngle >= 0)
            {
                aAngle = Mathf.Rad2Deg * rAngle;

            }
            else if (rAngle < 0)
            {
                aAngle = 360 + Mathf.Rad2Deg * rAngle;
            }


            if (aAngle == 0)
            {
                SeleccionPersonaje.sp.SeleccionPers(SeleccionPersonaje.sp.selectedPlayer);

                return;
            }

            if ((aAngle > 210 && aAngle < 300) && SelectACharacter)
            {
                es.SetSelectedGameObject(circulitos[0]);
            
            }
            if ((aAngle > 300 || aAngle < 90) && SelectACharacter)
            {
               es.SetSelectedGameObject(circulitos[1]);
              
            }
                                
            if ((aAngle > 90 && aAngle < 180) && SelectACharacter)
            {
               es.SetSelectedGameObject(circulitos[2]);
               
            }
            
        }
        else
        {
            if (SelectACharacter) {
                TogglePause();
            }
            
            //circle.GetComponent<Animator>().SetBool("OpenCircle", false);
            //GameObject.Find("ChicaSexy").GetComponent<PlayerController>().enabled = true;
            //GameObject.Find("ChicaSexy").GetComponent<PowerController>().enabled = true;
            //GameObject.Find("ChicaSexy").GetComponent<ShootController>().enabled = true;
        }
       
        
        
    }

    public void TogglePause()
    { 
        isPaused = !isPaused;
        Time.timeScale = isPaused ?  0: 1;
        if (isPaused)
        {
            SelectACharacter = true;
            circle.SetActive(true);
            circle.GetComponent<Animator>().SetBool("OpenCircle", true);
            // PauseMenu.SetActive(isPaused);
           
        }
        else
        {
            circle.GetComponent<Animator>().SetBool("OpenCircle", false);
            SelectACharacter = false;
            foreach (GameObject cir in circulitos)
            {
                cir.GetComponent<Animator>().SetBool("Highlighted", false);
            }
            
            // PauseMenu.SetActive(isPaused);
            

        }
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
