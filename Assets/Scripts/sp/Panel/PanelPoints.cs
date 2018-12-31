using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelPoints : MonoBehaviour {

    public Text ballsDestroyed;
    int balls=0;

    public Text totalFruits;
    int fruits=0;

    public Text totalTime;
    int time=100;

    public Text totalScoreCount;
    int totalScore=0;

    public Text gameScore;

    private void OnEnable()
    {
        balls = GameManager.gm.ballsDestroyed;

        ballsDestroyed.text = "X " + balls.ToString();

        fruits = GameManager.gm.fruitsTaken;

        totalFruits.text = "X " + fruits.ToString();

        time = (int) GameManager.gm.time+1;

        totalTime.text = "X " + time.ToString();

        SetTotalScore(ScoreManager.sm.currentScore);

        StartCoroutine("TotalScoreAmount");

    }
    void SetTotalScore(int score)
    {
        totalScore += score;
        totalScoreCount.text = totalScore.ToString();

    }

    public IEnumerator TotalScoreAmount()
    {
        yield return new WaitForSeconds(1);
        while (balls > 0)
        {
            balls--;
            SetTotalScore(100);
            ballsDestroyed.text = "X " + balls.ToString();
            ScoreManager.sm.UpdateScore(100);
            yield return new WaitForSeconds(0.1f);
        }
        while (fruits > 0)
        {
            fruits--;
            SetTotalScore(25);
            totalFruits.text = "X " + fruits.ToString();
            ScoreManager.sm.UpdateScore(25);
            yield return new WaitForSeconds(0.1f);
        }
        while (time > 0)
        {
            time--;
            SetTotalScore(15);
            totalTime.text = time.ToString() + " sec";
            ScoreManager.sm.UpdateScore(15);
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(1);

        if(SceneManager.sceneCountInBuildSettings > SceneManager.GetActiveScene().buildIndex + 1)
        {
            GameManager.gm.NextLevel();
        }
    
        //Cargar nivel
    }
}
