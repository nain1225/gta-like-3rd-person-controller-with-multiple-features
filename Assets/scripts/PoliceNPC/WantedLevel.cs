using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WantedLevel : MonoBehaviour
{
    public Player player;
    public bool WantedLevel1 = false;
    public GameObject Level01Star;
    public bool WantedLevel2 = false;
    public GameObject Level02Star;
    public bool WantedLevel3 = false;
    public GameObject Level03Star;
    public bool WantedLevel4 = false;
    public GameObject Level04Star;
    public bool WantedLevel5 = false;
    public GameObject Level05Star;


    private void Update()
    {
        if(player.KillCount >= 1)
        {
            WantedLevel1 = true;
            Level01Star.SetActive(true);
        }
        if (player.KillCount >= 3)
        {
            Level02Star.SetActive(true);
            WantedLevel2 = true;
        }
        if (player.KillCount >= 5)
        {
            Level03Star.SetActive(true);
            WantedLevel3 = true;
        }
        if (player.KillCount >= 10)
        {
            Level04Star.SetActive(true);
            WantedLevel4 = true;
        }
        if (player.KillCount > 11)
        {
            Level05Star.SetActive(true);
            WantedLevel5 = true;
        }
    }
}
