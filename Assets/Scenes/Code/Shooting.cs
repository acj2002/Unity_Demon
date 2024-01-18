using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject BulletPrefab;
    private Animator anim;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {


        if(Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("attack", true);
            Shoot();

        }
        else if (Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("attack", false);
            
        }

    }

    void Shoot()///ทิศการหันหน้า
    {
        int dir = -1;
        if(gameObject.transform.position.x > firePoint.position.x)
        {
            dir *= -1;
        }
        Instantiate(BulletPrefab, firePoint.position, Quaternion.Euler(0,0,90*dir));

        
    }

}
