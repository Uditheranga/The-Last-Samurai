using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerContoller : MonoBehaviour
{
    //movement variables
    public float maxSpeed;

    //jumping variables
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck; //location to build the circle
    public float jumpHeight;

    Rigidbody2D myRB;
    Animator myAnim;
    bool facingRight;

    bool isDead = false;

    float nextDamage;
    public float damageRate;

    private AudioSource footstep;


    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        facingRight = true;

        footstep = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isDead)
        {
            return;
        }
            

        if(grounded && Input.GetAxis("Jump")>0){

            SoundManager.PlaySound("Jump");

            grounded = false;
            myAnim.SetBool("isGrounded", grounded);
            myRB.AddForce(new Vector2(0, jumpHeight));
        }

    }

    void FixedUpdate()
    {
        //check if we are grounded if no then we are falling
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius,groundLayer);
        myAnim.SetBool("isGrounded", grounded);

        //vertical verlocity of RB
        myAnim.SetFloat("verticalSpeed", myRB.velocity.y);

        //getaxis take values between -1,0,1
        float move = Input.GetAxis("Horizontal");
        //take absalute value of move
        myAnim.SetFloat("speed", Mathf.Abs(move)); 

        //take velocity to change the movements 
        myRB.velocity = new Vector2(move * maxSpeed,myRB.velocity.y);

        if(move>0 && !facingRight)
        {
            flip();
        }
        else if(move<0 && facingRight)
        {
            flip();
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        //taking the scale values
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;    
    }
    
    public void Die()
    {
        isDead = true;
        //FindObjectOfType<LevelManager>().Restart();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && nextDamage<Time.time)
        {
            //SoundManager.PlaySound("Hit");

            FindObjectOfType<LifeCount>().LoseLife();
            Debug.Log("Enemy Hit"); 
            

            nextDamage = Time.time + damageRate;
            

        }
        if (collision.gameObject.tag == "EnemyDestroy" && nextDamage < Time.time)
        {


            nextDamage = Time.time + damageRate;
            Destroy(collision.transform.parent.gameObject);
        }
    }

    private void Footstep()
    {
        footstep.Play();
    }

}
