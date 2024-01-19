using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Flyattack : StateMachineBehaviour
{
    [SerializeField] private GameObject boll;
    [SerializeField] private float offsetY;
    private Boss boss;
    private Transform player;

   
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<Boss>();
        player = boss.player;

        boss.LookAtPlayer();

        Vector2 pos = new Vector2(player.position.x, player.position.y + offsetY);

        Instantiate(boll, pos, Quaternion.identity);

    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    
   
}
