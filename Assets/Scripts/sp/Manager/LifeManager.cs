using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {
    public int lifes = 3;
    public Text lifesTXT;
    public GameObject lifeDoll;
    Animator animator;
    private void Awake()
    {
        animator = lifeDoll.GetComponent<Animator>();
    }

  
	
	// Update is called once per frame
	public void AmountLifes () {
        lifes++;
        UpdateLifesText();
    }

    public void SubstractLifes()
    {
        lifes--;
        UpdateLifesText();
    }

    public void UpdateLifesText()
    {

        lifesTXT.text = "X " + lifes.ToString();
    }

    public void LifeWin()
    {
        animator.SetBool("win", true);
    }
    public void LifeLose()
    {
        animator.SetBool("lose", true);
    }

    public void RestartLifesDoll()
    {
        animator.SetBool("win", false);
        animator.SetBool("lose", false);
    }
}
