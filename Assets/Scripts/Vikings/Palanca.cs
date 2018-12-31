
using UnityEngine;

public class Palanca : MonoBehaviour {
    public GameObject puerta;
     Animator puertAnim;
    Animator palanca;
    Collider2D puertaCollider;
    bool isColliding;
    // Use this for initialization
    private void Awake()
    {
        palanca = GetComponent<Animator>();
        puertAnim = puerta.GetComponent<Animator>();
        puertaCollider = puerta.GetComponent<Collider2D>();
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isColliding && Input.GetButtonDown("Fire1"))
        {
            puertAnim.SetBool("Up", !puertAnim.GetBool("Up"));
            palanca.SetBool("Up", !palanca.GetBool("Up"));

        }
        if (!puertAnim.GetBool("Up"))
        {
            puertaCollider.enabled = false;
        }
        else
        {
            puertaCollider.enabled = true;
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isColliding = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isColliding = false;
    }
}
