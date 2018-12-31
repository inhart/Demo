using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gota : MonoBehaviour
{
    public GameObject gota;
    public float fuerza=50f;
    float time=0;
    public int numGotas=0;
    public int mod=1;
    bool spawning=true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(spawning && Mathf.Round(time)%mod == 0 && numGotas == 0)
        {
            Instantiate(gota,transform.position,Quaternion.identity);
            numGotas += 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().Pupita();
            collision.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-fuerza, fuerza/2),ForceMode2D.Impulse);
        }
        if (collision.gameObject.tag.Contains("Block"))
        {
            collision.transform.position = new Vector2(transform.position.x, collision.transform.position.y);
            collision.rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            collision.collider.isTrigger = true;
          
            GetComponent<BoxCollider2D>().enabled = false;
            
        }
    }
}
