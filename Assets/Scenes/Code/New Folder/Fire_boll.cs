using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_boll : MonoBehaviour
{

    [SerializeField] private Vector2 cast;
    [SerializeField] private Transform Pos;
    [SerializeField] private float tiem;

    public int damage;


    private void Start()
    {
        Destroy(gameObject, tiem);
    }

    public void attack()
    {
        Collider2D[] objetos = Physics2D.OverlapBoxAll(Pos.position, cast, 0f);
        foreach(Collider2D c in objetos)
        {
            if(c.CompareTag("Player"))
            {
                c.GetComponent<Player>().takeDamage(damage);
            }
        }
    }


    private void onDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Pos.position, cast);
    }


}
