using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManagerr : MonoBehaviour
{
    public float Score;
    public float Timer;
    public int Floor;
    public GameObject Player;
    public GameObject[] Lifebar;
    public GameObject[] Texts;
    
	// Use this for initialization
	void Start ()
    {
        Floor = 1;
        for (int i = 0; i < Texts.Length; i++)
        {
            Texts[i].SetActive(false);
            Texts[0].SetActive(true);
            Texts[3].SetActive(true);
            Texts[4].SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {      
        Texts[0].GetComponent<Text>().text = Floor.ToString() + " .solairua";
        Texts[3].GetComponent<Text>().text = Score.ToString();
        Texts[4].GetComponent<Text>().text = Timer.ToString("000");

        Timer = Time.time;
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }

        if (Player.GetComponent<PlayerHealth>().Vida > 80f)
        {
            for (int i = 0; i < Lifebar.Length; i++)
            {
                Lifebar[i].SetActive(true);
            }
        }

        if((Player.GetComponent<PlayerHealth>().Vida > 60f) && (Player.GetComponent<PlayerHealth>().Vida <= 80f))
        {
            for (int i = 0; i < Lifebar.Length; i++)
            {
                Lifebar[i].SetActive(true);
                Lifebar[4].SetActive(false);
            }
        }

        if((Player.GetComponent<PlayerHealth>().Vida > 40f) && (Player.GetComponent<PlayerHealth>().Vida <= 60f))
        {
            for (int i = 0; i < Lifebar.Length; i++)
            {
                Lifebar[i].SetActive(true);
                Lifebar[4].SetActive(false);
                Lifebar[3].SetActive(false);
            }
        }

        if((Player.GetComponent<PlayerHealth>().Vida > 20f) && (Player.GetComponent<PlayerHealth>().Vida <= 40f))
        {
            for (int i = 0; i < Lifebar.Length; i++)
            {
                Lifebar[i].SetActive(true);
                Lifebar[4].SetActive(false);
                Lifebar[3].SetActive(false);
                Lifebar[2].SetActive(false);
            }
        }

        if((Player.GetComponent<PlayerHealth>().Vida > 0f) && (Player.GetComponent<PlayerHealth>().Vida <= 20f))
        {
            for (int i = 0; i < Lifebar.Length; i++)
            {
                Lifebar[i].SetActive(true);
                Lifebar[4].SetActive(false);
                Lifebar[3].SetActive(false);
                Lifebar[2].SetActive(false);
                Lifebar[1].SetActive(false);
            }
        }

        if(Player.GetComponent<PlayerHealth>().Vida <= 0)
        {
            for (int i = 0; i < Lifebar.Length; i++)
            {
                Lifebar[i].SetActive(false);
                Texts[1].SetActive(true);
                Texts[2].SetActive(true);
            }
        }
    }
}
