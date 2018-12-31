using UnityEngine;

public class Monkey : MonoBehaviour
{
    public float fuerza= 50f;
   public int vidas = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vidas <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains("Player"))
        {
             collision.gameObject.GetComponent<PlayerMovement>().Pupita();
            collision.rigidbody.AddRelativeForce(new Vector2(-fuerza, fuerza/2),ForceMode2D.Impulse);
        }
        if (collision.gameObject.tag.Contains("Block"))
        {
            Destroy(collision.gameObject);
            vidas -= 1;
        }
    }
}
