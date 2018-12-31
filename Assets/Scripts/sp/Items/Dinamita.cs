using UnityEngine;

public class Dinamita : MonoBehaviour {

    bool inGround;
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

        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Ancle" || other.gameObject.tag == "Arrow")
        {

            Destroy(gameObject);

            //llamar corrutina
            BallManager.bm.Dinamite(5);
            HexagonManager.hm.Dinamite(4);
        }
    }

}
