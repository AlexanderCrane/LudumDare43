using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject fireMin;
    public GameObject waterMin;
    public GameObject bombMin;
    public GameObject regularMin;

    public bool isSpawned;
    public string type;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(!isSpawned)
        {
            SpawnMinion();
        }
		
	}

    void SpawnMinion()
    {
        if (type == "fire")
        {
            Instantiate(fireMin, transform.position, transform.rotation);
            isSpawned = true;
        }
        else if(type == "water")
        {
            Instantiate(waterMin, transform.position, transform.rotation);
            isSpawned = true;
        }
        else if(type == "bomb")
        {
            Instantiate(bombMin, transform.position, transform.rotation);
            isSpawned = true;
        }
        else if(type == "regular")
        {
            Instantiate(regularMin, transform.position, transform.rotation);
            isSpawned = true;
        }
        else
        {
            Debug.Log("ERROR: wrong type of minion passed in");
        }
    }
}
