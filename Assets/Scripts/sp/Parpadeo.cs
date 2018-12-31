using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Parpadeo : MonoBehaviour {

    float time;
    public GameObject pressStart;
    // Use this for initialization

    private void Start()
    {
        try
        {
            GameObject destroyOnLoad = FindObjectOfType<DontDestroy>().gameObject;
            if (destroyOnLoad != null)
            {
                Destroy(destroyOnLoad);
            }
        }
        catch(Exception e)
        {
            Debug.Log("no hay dontdestroy");
        }
       

      
    }
    // Update is called once per frame
    void Update () {
        time += Time.deltaTime;
		if(Mathf.Round(time)%2 == 0)
        {
            pressStart.SetActive(true);
        }
        else
        {
            pressStart.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetAxis("Jump")!=0)
        {
            SceneManager.LoadScene(1);
        }
	}
}
