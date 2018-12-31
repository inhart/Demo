using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicKeeper : MonoBehaviour {

    public GameObject musicPlayer;


    void Update()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start () {
		
	}
	
}
