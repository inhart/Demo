using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentShotImage : MonoBehaviour {
    public GameObject arrowShot;
    public GameObject anclaShot;
    public GameObject gunShot;

    public void CurrentShot(string shot)
    {
        if (shot.Equals("Arrow"))
        {
            arrowShot.SetActive(true);
            anclaShot.SetActive(false);
            gunShot.SetActive(false);
        }else if (shot.Equals("Ancla"))
        {
            arrowShot.SetActive(false);
            anclaShot.SetActive(true);
            gunShot.SetActive(false);
        }
        else if (shot.Equals("Gun"))
        {
            arrowShot.SetActive(false);
            anclaShot.SetActive(false);
            gunShot.SetActive(true);
        }
        else
        {
            arrowShot.SetActive(false);
            anclaShot.SetActive(false);
            gunShot.SetActive(false);
        }
    }
}
