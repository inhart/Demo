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
          
            if (kutxa != null)
            {
                kutxa.AddComponent<Rigidbody2D>();
                kutxa.AddComponent<BoxCollider2D>();
                kutxa.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                kutxa.transform.parent = null;
                
            }
            kutxa = null;
        }
        if (caching)
        {
           
        }
      
    }
  
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (caching && kutxa == null)
        {
            if (other.gameObject.tag == "Block")
            {
                kutxa = other.gameObject;
                other.transform.parent = transform;

                Destroy(other.gameObject.GetComponent<Rigidbody2D>());
                Destroy(other.collider);
               // other.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                
            }
        }

    }
   
    
}
