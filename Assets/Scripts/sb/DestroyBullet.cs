using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coll)
    {
        if((coll.gameObject.tag != "Player") && (coll.gameObject.tag != "LimiteMove"))
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }
}
