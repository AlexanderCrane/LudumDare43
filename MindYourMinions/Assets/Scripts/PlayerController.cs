using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public bool facingRight = true;
    public bool jump = false;
    public bool grounded = false;
    public Transform groundCheck;
    public MinionManager mm;
    public GameObject textObj;
    public Text textComp;
    public GameObject GameOverUI;
    public GameObject YouWinUI;

    public DoorCode endGoal;

    Animator anim;
    bool isBounced;
    float moveForce = 100f;
    float maxSpeed = 3f;
    float jumpForce = 2000f;
    //private Animator anim;
    private Rigidbody2D rb2d;


    // Use this for initialization
    void Awake()
    {
        //anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        mm = GetComponent<MinionManager>();

        textObj = GameObject.FindWithTag("ScoreText");
        textComp = textObj.GetComponent<Text>();

        GameOverUI = GameObject.FindWithTag("GameOverUI");
        GameOverUI.SetActive(false);

        YouWinUI = GameObject.FindWithTag("YouWinUI");
        YouWinUI.SetActive(false);

        anim = GetComponent<Animator>();


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

        if (h * rb2d.velocity.x < maxSpeed && !isBounced)
        {
            rb2d.AddForce(Vector2.right * h * moveForce);
        }

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed && !isBounced)
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

            jump = false;
            //anim.SetInteger("State", 2);

            grounded = false;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "EndGoal")
        {
            if (endGoal.Dooropen)
            {
                StartCoroutine(waitPls());

                YouWinUI.SetActive(true);
            }
            Debug.Log("End goal reached!");

        }
        else if(collision.gameObject.tag == "Minion" || collision.gameObject.tag == "FireMinion" || collision.gameObject.tag == "BombMinion" || collision.gameObject.tag == "WaterMinion")
        {
            if(collision.gameObject.GetComponent<MinionController>().isPickup)
            {
                mm.addMinion(collision.gameObject);

                textComp.text = "Lives: " + mm.minionQueue.Count;

                collision.gameObject.GetComponent<MinionController>().isPickup = false;

                collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            }
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            //Destroy(gameObject);
            //Destroy(this);
            //GameObject minionToLaunch = mm.removeFrontMinion();
            //mm.setDistances();

            //Vector3 dir = (collision.transform.position - transform.position).normalized;
            //Debug.DrawLine(collision.transform.position, transform.position * 100);
            if (mm.minionQueue.Count != 0)
            {
                GameObject minionToLaunch = mm.removeFrontMinion();
                minionToLaunch.transform.position = transform.position + new Vector3(0, 0.3f, 0);
                minionToLaunch.GetComponent<MinionController>().isLaunched = true;

                textComp.text = "Lives: " + mm.minionQueue.Count;

            }
            else
            {
                StartCoroutine(waitPls());

                GameOverUI.SetActive(true);
                //Destroy(this.gameObject);
            }


            if (facingRight)
            {
                rb2d.velocity = new Vector2(-5, 5);
                isBounced = true;
            }
            else
            {
                rb2d.velocity = new Vector2(5, 5);
                isBounced = true;
            }
            //rb2d.AddForce(new Vector2(0f, jumpForce));
        }
        else if (collision.gameObject.tag == "Ground" && grounded == false)
        {
            //dontMove = true;
            //anim.SetInteger("State", 0);


            //anim.SetInteger("State", 0);
            

            grounded = true;
            isBounced = false;
            mm.setDistances();

            mm.jumpAllMinions();

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

        mm.setDistances();

        mm.reverseDistances();

    }

    void launchMinion()
    {
        if (mm.minionQueue.Count != 0)
        {
            GameObject minionToLaunch = mm.removeFrontMinion();
            minionToLaunch.transform.position = transform.position;
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

            textComp.text = "Lives: " + mm.minionQueue.Count;

        }
    }

    IEnumerator waitPls()
    {

        //returning 0 will make it wait 1 frame
        yield return 1;

        //code goes here


    }

}
