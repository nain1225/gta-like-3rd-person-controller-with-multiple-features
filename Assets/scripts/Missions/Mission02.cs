using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission02 : MonoBehaviour
{
    public Missions mission;
    public Player player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (mission.mission01 == true && mission.mission03 == false && mission.mission04 == false)
            {
                mission.mission02 = true;
                player.PlayerMoney += 500;
            }
        }
        
    }
}
