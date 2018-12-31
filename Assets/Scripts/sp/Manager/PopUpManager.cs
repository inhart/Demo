using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour {

    public GameObject popupText;
    public static PopUpManager pop;
    private void Awake()
    {
        if (pop == null)
        {
            pop = this;
        }
        if (pop != this)
        {
            Destroy(gameObject);
        }
    }
    public void InstanciatePopUpText(Vector2 startPos, int textScore)
    {
        GameObject pop = Instantiate(popupText);

        pop.transform.position = startPos;

        pop.GetComponent<TextMesh>().text = textScore.ToString();

    }
}
