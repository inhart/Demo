using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager sm;

    public Text scoreTXT;
    public int currentScore = 0;

    public Text hiScoreText;
    public int hiScore = 500;


    private void Awake()
    {
        if (sm == null)
        {
            sm = this;
        }
        if (sm != this)
        {
            Destroy(gameObject);
        }

    }
    
    void Start () {
        currentScore = 0;
        scoreTXT.text = currentScore.ToString();
	}
	
	
	public void UpdateScore(int score)
    {
        currentScore += score;
        scoreTXT.text = currentScore.ToString();

        if (currentScore > hiScore)
        {
            hiScore = currentScore;
            hiScoreText.text = "HI - " + hiScore.ToString();

            PlayerPrefs.SetInt("HiScore", hiScore);

        }
    }

    public void UpdateHiScore()
    {
        hiScore = PlayerPrefs.GetInt("HiScore");
        hiScoreText.text = "HI - " + hiScore.ToString();
    }
}
