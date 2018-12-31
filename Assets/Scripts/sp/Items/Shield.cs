
using UnityEngine;

public class Shield : MonoBehaviour {
    bool inGround;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (!inGround)
        {
            transform.position += Vector3.down * Time.deltaTime * 2;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "lurra")
        {
            inGround = true;
            Destroy(gameObject, 60);

        }

        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().shield.SetActive(true);
            other.gameObject.GetComponent<Player>().blink = false;
            Destroy(gameObject);
        }
    }

}
