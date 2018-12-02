using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowManCode : MonoBehaviour
{
    bool isDamaged;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isDamaged == true)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnCollisionEnter2D(Collision2D Other)
    {
        if (Other.gameObject.tag == "FireMinion")
        {
           isDamaged = true;
        }
    }
}