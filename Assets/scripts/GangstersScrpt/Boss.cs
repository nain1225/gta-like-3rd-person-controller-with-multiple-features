using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float health = 120;
    public Animator animator;
    public Player player;
    public Missions mission;

    private void Update()
    {
        if (health < 120)
        {
            animator.SetBool("Shoot", true);

        }
        if (health <= 0)
        {
            if (mission.mission01 == true && mission.mission02 == true && mission.mission03 == true)
            {
                mission.mission04 = true;
                player.PlayerMoney += 500;
            }
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            animator.SetBool("Die", true);
            //Destroy(this.gameObject, 4f);
            Object.Destroy(gameObject, 4f);
        }
    }
    public void characterHitDamage(float takeDamge)
    {
        health -= takeDamge;
    }
}
