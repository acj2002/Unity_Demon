using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    
    private float dirX = 0f;
    public bool isJumping;

    public int maxHealth = 100;
    public int currentHealth;

    public HPBar healthBar;
    

    bool facingRight = true;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 200f;
    private float dashingTime = 0.2f;
    private float dashingColldown = 1f;


    [SerializeField] float movespeed = 7f;
    [SerializeField] float jumpForce = 14f;
    [SerializeField] private TrailRenderer tr;



    private Animator anim;


   void Start()
    {

        currentHealth = maxHealth;
        healthBar.setMaxHp(maxHealth);
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();        
    }

    void Update()
    {

        if(isDashing)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            takeDamage(20);
        }

        if(currentHealth <=0)
        {
            anim.SetTrigger("die");
        }

        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * movespeed, rb.velocity.y);

      

        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
          rb.velocity = new Vector2(rb.velocity.x, jumpForce);
           anim.SetTrigger("jump");
        }


        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        if(dirX == 0)
        {
            anim.SetBool("run", false);
        }
        else
        {
            anim.SetBool("run", true);
        }


        UpdateAnimatiorUpdate();
        
    }

    private void UpdateAnimatiorUpdate()
    {
        if(dirX > 0 && !facingRight)
        {
            Flip();
            
        }
        else if(dirX < 0 && facingRight)
        {
            Flip();
            
        }
       
        
    }
    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
        //transform.Rotate(0, 180, 0);
    }

    private void FixedUpdate()
    {
        if(isDashing)
        {
            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }


    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isJumping = true;
        }



    }


    public IEnumerator Dash()
    {

        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingColldown);
        canDash = true;
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.setHp(currentHealth);
        anim.SetTrigger("hit");

    }

}
