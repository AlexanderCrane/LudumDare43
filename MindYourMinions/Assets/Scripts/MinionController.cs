using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionController : MonoBehaviour {

    public GameObject player;

    public GameObject spawner;

    public float desiredDistance = 2f;

    public float moveSpeed = 5f;

    public bool isPickup = true;

    public bool isLaunched = false;

	// Use this for initialization
	void Start () {

        player = GameObject.FindWithTag("Player");

        GetComponent<Rigidbody2D>().gravityScale = 0;

        if(gameObject.tag == "FireMinion")
        {
            spawner = GameObject.FindWithTag("FireSpawner"); //currently only allows for one copy of each type of spawner in a given level
        }
        else if(gameObject.tag == "WaterMinion")
        {
            spawner = GameObject.FindWithTag("FireSpawner");
        }
        else if(gameObject.tag == "BombMinion")
        {
            spawner = GameObject.FindWithTag("FireSpawner");
        }
        else if(gameObject.tag == "Minion")
        {
            spawner = GameObject.FindWithTag("FireSpawner");
        }

    }
	
	// Update is called once per frame
	void Update () {
        //desiredXPos = player.transform.position.x + 1;

        /*if(transform.position.x <= desiredXPos )
        {
            transform.Translate(new Vector2(1, 0));
        }
        else if(transform.position.x > desiredXPos)
        {
            transform.Translate(new Vector2(-1, 0));
        }*/

        if (Vector2.Distance(transform.position, player.transform.position) != desiredDistance && !isPickup && !isLaunched)
        {//move if distance from target is greater than 1
            //transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x + desiredDistance, player.transform.position.y), moveSpeed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, player.transform.position) >= 10f && !isPickup && !isLaunched)
        {
            transform.position = player.transform.position;
        }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Minion" || collision.gameObject.tag == "FireMinion" || collision.gameObject.tag == "BombMinion" || collision.gameObject.tag == "WaterMinion" && !isPickup)
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        if((collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Obstacle") && isLaunched)
        {
            Destroy(this.gameObject);
        }
    }

    public void setDesiredDistance(float d)
    {
        desiredDistance = d;

        Debug.Log("Desired distance set to " + d);
    }
}
