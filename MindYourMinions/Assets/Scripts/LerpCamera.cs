using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpCamera : MonoBehaviour
{


    public float FollowSpeed = 10f;
    public GameObject player;
    public float verticalOffset = 2f;
    public float horizontalOffset = 2f;
    //public float zOffset = -1f;


    Transform Target;

    void Start()
    {
        Target = player.transform;
    }

    private void FixedUpdate()
    {
        if (Target != null)
        {
            Vector3 newPosition = Target.position;
            //newPosition.z = zOffset;
            transform.position = Vector3.Lerp(transform.position, newPosition + new Vector3(horizontalOffset, verticalOffset, -7), FollowSpeed * Time.deltaTime);
        }
    }
}
