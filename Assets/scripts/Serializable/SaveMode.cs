using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveMode : MonoBehaviour
{
    public Missions mission;
    public Player player;

    public GameObject SavePannel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.SavePlayer();
            StartCoroutine(SaveUI());
        }
        if(mission.mission02 == false && mission.mission03 == false && mission.mission04 == false)
        {
            mission.mission01 = true;
            player.PlayerMoney += 400;

        }
    }
    IEnumerator SaveUI()
    {
        SavePannel.SetActive(true);
        yield return new WaitForSeconds(2f);
        SavePannel.SetActive(false);
    }
}
