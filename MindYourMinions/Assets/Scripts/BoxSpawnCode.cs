using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BoxSpawnCode : MonoBehaviour {
    bool Spawnstart1;
    bool Spawnstart2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Spawnstart1 == true)
        {
           ;
        }
        else if (Spawnstart2 == true)
        {
            ;
        }
    }


private void OnCollisionEnter2D(Collision2D Box1, Collision2D Box2)
{
    if (Box1.gameObject.tag == "Player")
    {
        Spawnstart1 = true;

    }
    else if (Box2.gameObject.tag == "Player")
        {
            Spawnstart2 = true;
        }
    }

}