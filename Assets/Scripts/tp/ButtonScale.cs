using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


    public class ButtonScale : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler{

    public bool isin;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        if(isin == true)
        {
            gameObject.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
        }
        if(isin == false)
        {
            gameObject.transform.localScale -= new Vector3(0.01f, 0.01f, 0.01f);
        }

        if (gameObject.transform.localScale.x >= 1.1f && gameObject.transform.localScale.y >= 1.1f && gameObject.transform.localScale.z >= 1.1f)
        {
            gameObject.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        }
        if (gameObject.transform.localScale.x <= 0.999f && gameObject.transform.localScale.y <= 0.999f && gameObject.transform.localScale.z <= 0.999f)
        {
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isin = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        isin = false;
    }
}

