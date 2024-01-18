using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFiy : MonoBehaviour
{
    public float speed;
    public bool chase = false;
    public Transform staringPoint;
    private GameObject player;


    public int damage;
    public Player playerHp;
   
    void Start()
    {
       
        player = GameObject.FindGameObjectWithTag("Player");
    }

   
    void Update()
    {
        if (player == null)
            return;
        if (chase == true)
            Chase();
        else
            ReturnStartPoint();
        Flip();

       

    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void ReturnStartPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, staringPoint.position, speed * Time.deltaTime);
    }

    private void Flip()
    {
        if (transform.position.x > player.transform.position.x)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }


   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag== "Player")
        {

            playerHp.takeDamage(damage);
           

        }
    }











}
