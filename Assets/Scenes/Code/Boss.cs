using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

	public Transform player;

	public int maxHealth = 300;
	public int currentHealth;

	public HPBarBoss hpBoss;

	public bool isFlipped = false;



    private void Awake()
    {
		currentHealth = maxHealth;
		hpBoss.setMaxHpboss(maxHealth);
	}

    private void Update()
    {
		if (Input.GetKeyDown(KeyCode.T))
		{
			takeDamage(20);
		}
	}


    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }



    }

    public void takeDamage(int damage)
		{
			currentHealth -= damage;
			hpBoss.setHpboss(currentHealth);

		}








}
