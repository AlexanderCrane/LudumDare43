using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public bool facingRight = true;
    public bool jump = false;
    float moveForce = 100f;
    float maxSpeed = 3f;
    float jumpForce = 2000f;
    public Transform groundCheck;
    public bool grounded = false;
    public MinionManager mm;

    //private Animator anim;
    private Rigidbody2D rb2d;




    // Use this for initialization
    void Awake()
    {
        //anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        mm = GetComponent<MinionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetKeyDown("up") || Input.GetKeyDown("w") && grounded)
        {
            jump = true;
        }

        if (Input.GetKeyDown("space"))
        {
            //print("space key was pressed");
            launchMinion();
        }



    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal"); //what is this?
        //Debug.Log(h);
        //anim.SetFloat("Speed", Mathf.Abs(h));

        if (h * rb2d.velocity.x < maxSpeed)
        {
            rb2d.AddForce(Vector2.right * h * moveForce);
        }

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
        {
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
        }

        if (h > 0 && !facingRight)
        {
            Flip();
        }
        else if (h < 0 && facingRight)
        {
            Flip();
        }

        if (jump)
        {
            //anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            mm.jumpAllMinions();

            jump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "EndGoal")
        {
            Debug.Log("End goal reached!");

        }
        else if(collision.gameObject.tag == "Minion")
        {
            if(collision.gameObject.GetComponent<MinionController>().isPickup)
            {
                mm.addMinion(collision.gameObject);

                collision.gameObject.GetComponent<MinionController>().isPickup = false;

                collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            }
        }
        else if (collision.gameObject.tag == "Deadly")
        {
            //Destroy(gameObject);
            //Destroy(this);
        }
        else if (collision.gameObject.tag == "Ground")
        {
            //dontMove = true;
            //anim.SetInteger("State", 0);

            //if (dontMove)
            //{
            //    anim.SetInteger("State", 2);
            //}

            grounded = true;
            Debug.Log("Grounded");
        }
        else if (collision.gameObject.tag == "MovingPlatform")
        {
            Debug.Log("Collided with moving platform");
            //anim.SetInteger("State", 2);
            grounded = true;
            //tempTrans = transform.parent;
            transform.parent = collision.transform;
            //dontMove = true;
            //onMovingPlatform = true;

        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
            //Debug.Log("No longer grounded");
        }
        else if (collision.gameObject.tag == "MovingPlatform")
        {
            Debug.Log("Collision ended with moving platform");

            grounded = false;

            //transform.parent = null;
            //dontMove = false;
            //onMovingPlatform = false;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

        mm.reverseDistances();
    }

    void launchMinion()
    {
        if (mm.minionQueue.Count != 0)
        {
            GameObject minionToLaunch = mm.removeFrontMinion();
            minionToLaunch.GetComponent<MinionController>().isLaunched = true;

            if (facingRight)
            {
                minionToLaunch.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 5);
            }
            else
            {
                minionToLaunch.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 5);
            }

            mm.setDistances();
        }
    }
}
