using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int PlayerMoney;
    //public Player player;
    public float[] position;

    public bool isWeapon1Picked;
    public bool isWeapon2Picked;
    public bool isWeapon3Picked;
    public bool isWeapon4Picked;

    public bool mission01;
    public bool mission02;
    public bool mission03;
    public bool mission04;

    public PlayerData(Player player)
    {
        PlayerMoney = player.PlayerMoney;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        isWeapon1Picked = player.inventory.isWeapon1Picked;
        isWeapon2Picked = player.inventory.isWeapon2Picked;
        isWeapon3Picked = player.inventory.isWeapon3Picked;
        isWeapon4Picked = player.inventory.isWeapon4Picked;

        mission01 = player.missions.mission01;
        mission02 = player.missions.mission02;
        mission03 = player.missions.mission03;
        mission04 = player.missions.mission04;
    }
}
