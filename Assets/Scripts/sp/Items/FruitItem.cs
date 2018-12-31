using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitItem : MonoBehaviour {
    bool inGround;

    public Sprite[] fruitSprites;
    SpriteRenderer sr;
    // Use this for initialization
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void Start () {
        sr.sprite = fruitSprites[Random.Range(0, fruitSprites.Length)];
        gameObject.name = sr.sprite.name;
	}
	
	// Update is called once per frame
	void Update () {
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
            Destroy(gameObject, 15);
        }else if (other.gameObject.tag == "Player" || other.gameObject.tag == "Arrow" || other.gameObject.tag == "Ancla"  )
        {
            int score = Random.Range(500, 1001);
            ScoreManager.sm.UpdateScore(score);
            PopUpManager.pop.InstanciatePopUpText(transform.position, score);
            GameManager.gm.fruitsTaken++;
            Destroy(gameObject);

        }
    }
}
