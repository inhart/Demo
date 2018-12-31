
using UnityEngine;

public class Puerta : MonoBehaviour {

	
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<Animator>().SetBool("Open", true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<Animator>().SetBool("Open", false);
    }
}
