using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MinionManager : MonoBehaviour
{

    //Array approach
    //~~~~~~~~~~~~~~~~~~~~~~~~
    /*public GameObject[] minionArray;

    public GameObject minion1;
    public GameObject minion2;
    public GameObject minion3;
    public GameObject minion4;
    public GameObject minion5;*/
    //~~~~~~~~~~~~~~~~~~~~~~~~

    //List approach
    //~~~~~~~~~~~~~~~~~~~~~~~~
    public Queue<GameObject> minionQueue;

    GameObject minionRef;

    GameObject player;

    //~~~~~~~~~~~~~~~~~~~~~~~~

    // Use this for initialization
    void Start()
    {
        //minionArray = new GameObject[5]; //initialize the gameobject array to size 5

        minionQueue = new Queue<GameObject>();

        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addMinion(GameObject min)
    {
        if (minionQueue.Count < 5)
        {
            minionQueue.Enqueue(min);

            setDistances();

            /*if(player.GetComponent<PlayerController>().facingRight)
            {
                reverseDistances();
            }
            else
            {
                setDistances();
            }*/

            Debug.Log("Minion added to queue");

        }
        else
        {
            Debug.Log("Too many minions!");
        }
    }

    public GameObject removeFrontMinion() //removes and returns minion
    {
        return minionQueue.Dequeue();
    }

    public void setDistances()
    {
        for (int i = 0; i < minionQueue.Count; i++)
        {
            minionRef = minionQueue.ElementAt<GameObject>(i);

            if (i == 0)
            {
                minionRef.GetComponent<MinionController>().setDesiredDistance(1);
            }
            else if (i == 1)
            {
                minionRef.GetComponent<MinionController>().setDesiredDistance(2);
            }
            else if (i == 2)
            {
                minionRef.GetComponent<MinionController>().setDesiredDistance(3);
            }
            else if (i == 3)
            {
                minionRef.GetComponent<MinionController>().setDesiredDistance(4);
            }
            else if (i == 4)
            {
                minionRef.GetComponent<MinionController>().setDesiredDistance(5);
            }
            else if (i == 5)
            {
                minionRef.GetComponent<MinionController>().setDesiredDistance(6);
            }
            else
            {
                Debug.Log("ERROR: too many items in queue");
            }
        }

    }

    public void reverseDistances()
    {
        Debug.Log("Reverse distances");

        //if((player.GetComponent<PlayerController>().facingRight && ))
        for (int i = 0; i < minionQueue.Count; i++)
        {
            minionRef = minionQueue.ElementAt<GameObject>(i);

            minionRef.GetComponent<MinionController>().setDesiredDistance(minionRef.GetComponent<MinionController>().desiredDistance * -1);

            //minionRef.GetComponent<MinionController>().moveSpeed *= -1;
        }
    }

    public void jumpAllMinions()
    {
        for (int i = 0; i < minionQueue.Count; i++)
        {
            minionRef = minionQueue.ElementAt<GameObject>(i);

            minionRef.transform.position = player.transform.position;
        }
    }
}
