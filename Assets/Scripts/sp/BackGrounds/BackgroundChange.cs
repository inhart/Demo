using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackgroundChange : MonoBehaviour {

    public Sprite[] backgrounds;

    Image currentBackground;
	// Use this for initialization
	void Start () {
        Background();
	}
    public void Background()
    {
        currentBackground = GetComponent<Image>();

        if (GameManager.gm.gamemode== GameMode.TOUR)
        {
            currentBackground.sprite = backgrounds[SceneManager.GetActiveScene().buildIndex - 3];
        }
        else
        {
            currentBackground.sprite = backgrounds[GameManager.gm.currentLvl-1];
        }
      
    }
	

}
