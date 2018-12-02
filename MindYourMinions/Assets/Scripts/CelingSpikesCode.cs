using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelingSpikesCode : MonoBehaviour
{
    bool isUnder;
    Vector2 startposition;
    Vector2 moveposition;
    bool isDamaged;
    // Use this for initialization
    public GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        startposition = transform.position;
        moveposition = new Vector2(startposition.x, startposition.y - 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDamaged == true)
        {
            Destroy(this.gameObject);
        }
        else if (isUnder == true && transform.position.y >= moveposition.y)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.1f);
        }
        else if (isUnder == false && transform.position.y < startposition.y)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.1f);
        }
    }


    private void OnCollisionEnter2D(Collider2D Other)
    {
        if (Other.gameObject.tag == "BombMinion")
        {
            isDamaged = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.tag == "Player" || Other.gameObject.tag == "BombMinion"|| Other.gameObject.tag == "FireMinion" || Other.gameObject.tag == "WaterMinion" || Other.gameObject.tag == "HeavyMinion" || Other.gameObject.tag == "NormalMinion" || Other.gameObject.tag == "Minion")
        {
            isUnder = true;
        }
    }
}