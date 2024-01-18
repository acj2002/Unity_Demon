using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_01 : MonoBehaviour
{
    public Transform rayCast;
    public Transform rayCastEye;
    public LayerMask raycastMask;
    public float rayCastLength;
    public float attackDistance;
    public float moveSpeed;
    public float timer;
   

    public Transform leftLimit;
    public Transform rightLimit;
    

    

    private RaycastHit2D Hit;
    private Transform target;
    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float inTimer;
    public float targetTime;
    

    private Rigidbody2D rb;
    float jumpForce = 10f;

    
    public int damage;
    public Player playerHp;


    void Awake()
    {
        SelectTarget();
        inTimer = timer;
        anim = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (eyeEnamy())
        {
            targetTime -= Time.deltaTime;
            if (targetTime <= 0)
            {
                targetTime = Random.Range(0, 2);
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }

        if(!attackMode)
        {
            Move();
        }

        if(!InsideofLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_attack_01"))
        {
            SelectTarget();
        }

        if(inRange)
        {
            Hit = Physics2D.Raycast(rayCast.position, transform.right*-1, rayCastLength, raycastMask);
            RaycastDebugger();
        }

        

        if(Hit.collider != null)
        {
            EnemyLogic();

        }else if(Hit.collider == null)
        {
            inRange = false;
        }
        if(inRange == false)
        {
            
            stopAttack();


        }


    }

    private void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag == "Player")
        {

            target = trig.transform;
            inRange = true;
            Flip();

        }
        
        

    }
   



    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);

        if (distance > attackDistance)
        {
            stopAttack();
        }
        else if (attackDistance >= distance && cooling == false)
        {
            Attack();
            
            
        }
        if(cooling)
        {
            coolDowe();
            anim.SetBool("attack", false);
        }

    }

    void Move()
    {

        anim.SetBool("canWalk", true);
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_attack_01"))
        {
            Vector2 targetPostion = new Vector2(target.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPostion, moveSpeed * Time.deltaTime);
            
        }
    }

    void Attack()
    {
        timer = inTimer;


        attackMode = true;
        anim.SetBool("canWalk", false);
        anim.SetBool("attack", true);
        
    }

    void coolDowe()
    {
        timer -= Time.deltaTime;

        if(timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = inTimer;
        }
    }

    void stopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("attack", false);
    }

    public void RaycastDebugger()
    {
        if(distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, transform.right *-1* rayCastLength, Color.red);

        }
        else if (attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, transform.right *-1* rayCastLength, Color.green);
        }

    }

    public void TriggerCooling()
    {
        playerHp.takeDamage(damage);
        cooling = true;
    }


   private bool InsideofLimits()
    {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }


    private void SelectTarget()
    {
        float distancToLeft = Vector2.Distance(transform.position, leftLimit.position);
        float distancToRight = Vector2.Distance(transform.position, rightLimit.position);

        if(distancToLeft > distancToRight)
        {
            target = leftLimit;
        }
        else
        {
            target = rightLimit;
        }

        Flip();

    }


    private void Flip ()
    {
         Vector3 rotation = transform.eulerAngles;

        if(transform.position.x > target.position.x)
        {
            rotation.y = 0f;
        }
        else
        {
            rotation.y = 180f;
        }

        transform.eulerAngles = rotation;
    }


    private bool eyeEnamy()
    {
        Collider2D[] ray = Physics2D.OverlapBoxAll(rayCastEye.position, new Vector2(8,10), Quaternion.identity.x);

        foreach (var item in ray)
        {
            if (item.tag == "bulletc")
            {
                return true;
            }
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(rayCastEye.position, new Vector2(10, 4));
    }
}
