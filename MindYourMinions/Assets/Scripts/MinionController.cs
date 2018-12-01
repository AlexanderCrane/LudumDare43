using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionController : MonoBehaviour {

    public GameObject player;

    public float desiredDistance = 2f;

	// Use this for initialization
	void Start () {
		
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

        if (Vector2.Distance(transform.position, player.transform.position) > desiredDistance)
        {//move if distance from target is greater than 1
            transform.Translate(new Vector3(5 * Time.deltaTime, 0, 0));
        }

    }
}
