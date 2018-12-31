using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void EstzenaAldatu(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void Irten()
    {
        Application.Quit();
    }
}
