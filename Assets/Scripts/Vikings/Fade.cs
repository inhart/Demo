
using UnityEngine;

public class Fade : MonoBehaviour {
    
    Animator fader;
    public float fade;
    // Use this for initialization
    private void Awake()
    {
       
        fader = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        fader.SetBool("fade", true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        fader.SetBool("fade", false);
    }
}
