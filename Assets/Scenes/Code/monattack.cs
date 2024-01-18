using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class monattack : MonoBehaviour
{
    public int damage;
    public Player playerHp;


    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
       {
          playerHp.takeDamage(damage);
      }
    }
    

}
