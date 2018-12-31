using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerController : MonoBehaviour {

    public GameObject LaserLeft;
    public GameObject LaserRight;
    public static int playerPower = 0;
    public Slider playerPowerSlider;
    public PlayerController_tp p_c;
    public bool PowerIsOn = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        playerPowerSlider.value = playerPower;
        if ((Input.GetKeyDown(KeyCode.E)) ||(Input.GetButtonDown("Square")))
        {
            Debug.Log("Pum");
        }
        if(playerPower >= 100)
        {
            playerPower = 100;
        }
        if ((playerPower == 100) && (Input.GetKeyDown(KeyCode.E)) || (Input.GetButtonDown("Square")) && (p_c.IsFlipped == false))
        {
            LaserRight.SetActive(true);
            Debug.Log("powering");
            PowerIsOn = true;
        }
        if ((playerPower == 100) && (Input.GetKeyDown(KeyCode.E)) || (Input.GetButtonDown("Square")) && (p_c.IsFlipped == true))
        {
            LaserLeft.SetActive(true);
            Debug.Log("powering");
            PowerIsOn = true;
        }
        if ((playerPower == 0) && (p_c.IsFlipped == true))
        {
            PowerIsOn = false;
        }
        if ((playerPower == 0) && (p_c.IsFlipped == false))
        {
            PowerIsOn = false;
        }
        if ((PowerIsOn == true) && (p_c.IsFlipped == true))
        {
            LaserLeft.SetActive(true);
            gameObject.GetComponent<Animator>().SetBool("Shooting", true);
            LaserLeft.GetComponentInChildren<Image>().fillAmount += 0.1f;
            playerPower -= 1;
        }
        if ((PowerIsOn == true) && (p_c.IsFlipped == false))
        {
            LaserRight.SetActive(true);
            LaserRight.GetComponentInChildren<Image>().fillAmount += 0.1f;
            playerPower -= 1;
        }
        if(PowerIsOn == false)
        {
            LaserRight.SetActive(false);
            LaserLeft.SetActive(false);
        }
    }
}
