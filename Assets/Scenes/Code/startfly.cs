using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startfly : MonoBehaviour
{
    public EnemyFiy[] enemyFiys;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (EnemyFiy enemy in enemyFiys)
            {
                enemy.chase = true;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (EnemyFiy enemy in enemyFiys)
            {
                enemy.chase = false;
            }
        }
    }



}
