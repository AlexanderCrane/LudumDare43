using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesMover : MonoBehaviour {

    public GameObject spikes;
    public GameObject player;

    bool moveSpikes;
    Vector2 startposition;
    Vector2 moveposition;


    // Use this for initialization
    void Start () {
        //player = GameObject.FindWithTag("Player");
        startposition = spikes.transform.position;
        moveposition = new Vector2(startposition.x, startposition.y - 2.7f);

    }

    // Update is called once per frame
    void Update () {
        if (moveSpikes == true && spikes.transform.position.y >= moveposition.y)
        {
            spikes.transform.position = new Vector2(spikes.transform.position.x, spikes.transform.position.y - 0.1f);

            if (spikes.transform.position.y <= moveposition.y)
            {
                moveSpikes = false;
            }
        }
        else if (spikes.transform.position.y <= startposition.y)
        {
            spikes.transform.position = new Vector2(spikes.transform.position.x, spikes.transform.position.y + 0.1f);
        }

    }

    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.tag == "Player" || Other.gameObject.tag == "BombMinion" || Other.gameObject.tag == "FireMinion" || Other.gameObject.tag == "WaterMinion" || Other.gameObject.tag == "HeavyMinion" || Other.gameObject.tag == "NormalMinion" || Other.gameObject.tag == "Minion")
        {
            moveSpikes = true;
        }
    }

}
