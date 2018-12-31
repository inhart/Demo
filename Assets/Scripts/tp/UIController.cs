using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text Score_text;
    public Text Lifes_text;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;
    public GameObject Heart4;
    public GameObject Heart5;

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update () {
        Score_text.text = GameController_tp.Score.ToString();
        Lifes_text.text = "x"+"  " + PlayerController_tp.playerLifes.ToString();
    }
}
