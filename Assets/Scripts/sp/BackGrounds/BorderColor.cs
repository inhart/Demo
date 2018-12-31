using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BorderColor : MonoBehaviour {

    float time;
    Image borderColor;
    bool danger;

    Color normalColor;
    Color dangerColor;
    private void Awake()
    {
        borderColor = GetComponent<Image>();
    }
    // Use this for initialization
    void Start () {
        normalColor = borderColor.color;
        dangerColor = Color.red;
	}

    // Update is called once per frame
    void Update() {
        if( GameManager.gm.gamemode == GameMode.TOUR)
        {
            time = GameManager.gm.time;
            if (time < 10 && !danger)
            {
                StartCoroutine("Danger");
            }
        }
    }

    IEnumerator Danger()
    {
        danger = true;
        while(time > 0)
        {
            if(borderColor.color == normalColor)
            {
                borderColor.color = dangerColor;

            }
            else
            {
                borderColor.color = normalColor;
            }
            yield return new WaitForSeconds(0.3f);
        }
    }
}
