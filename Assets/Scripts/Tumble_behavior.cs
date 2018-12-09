
using UnityEngine;

public class Tumble_behavior : MonoBehaviour
{
    public bool caching;
    public GameObject kutxa;
    public static Tumble_behavior tb;

    private void Awake()
    {
        if(tb == null)
        {
            tb = this;
        }
        else
        {
            Destroy(this);
        }
      
    }
    // Use this for initialization
   
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            caching = !caching;
        }
        if (!caching)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255 / 255, 85/255f, 106 / 255f, 1f);
            if (transform.childCount != 0)
            {
                kutxa.AddComponent<Rigidbody2D>();
                transform.DetachChildren();
                
            }
            kutxa = null;
        }
        if (caching)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(253f / 255, 0f, 30 / 255f, 1f);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (caching)
        {
            if (other.gameObject.tag == "Block")
            {
                kutxa = other.gameObject;
                other.transform.parent = transform;
                Destroy(other.gameObject.GetComponent<Rigidbody2D>());
               // other.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                
            }
        }

    }
   
    
}
