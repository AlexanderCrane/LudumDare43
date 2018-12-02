using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelingSpikesCode : MonoBehaviour
{
    bool moveSpikes;
    Vector2 startposition;
    Vector2 moveposition;
    bool isDamaged;
    // Use this for initialization
    public GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        startposition = transform.position;
        moveposition = new Vector2(startposition.x, startposition.y - 2.7f);
    }

    // Update is called once per frame
    void Update()
    {
        if(moveSpikes == true && transform.position.y >= moveposition.y)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.1f);

            if(transform.position.y <= moveposition.y)
            {
                moveSpikes = false;
            }
        }
        else if (transform.position.y <= startposition.y)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + 0.1f);
        }
    }


    private void OnCollisionEnter2D(Collision2D Other)
    {
        if (Other.gameObject.tag == "BombMinion")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.tag == "Player" || Other.gameObject.tag == "BombMinion"|| Other.gameObject.tag == "FireMinion" || Other.gameObject.tag == "WaterMinion" || Other.gameObject.tag == "HeavyMinion" || Other.gameObject.tag == "NormalMinion" || Other.gameObject.tag == "Minion")
        {
            moveSpikes = true;
        }
    }
}