using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rompe_Gotas : MonoBehaviour
{
    public GameObject spawner;
    private void Awake()
    {
        spawner = GameObject.Find("Gota_spawner");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag.Contains("Floor"))
        {
            Destroy(gameObject);
            spawner.GetComponent<Gota>().numGotas -= 1;
        }
    }
}
