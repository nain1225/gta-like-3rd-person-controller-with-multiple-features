using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player money")]
    public int PlayerMoney;
    public int KillCount;

    public Inventory inventory;
    public Missions missions;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        PlayerMoney = data.PlayerMoney;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

        inventory.isWeapon1Picked = data.isWeapon1Picked;
        inventory.isWeapon2Picked = data.isWeapon2Picked;
        inventory.isWeapon3Picked = data.isWeapon3Picked;
        inventory.isWeapon4Picked = data.isWeapon4Picked;

        missions.mission01 = data.mission01;
        missions.mission02 = data.mission02;
        missions.mission03 = data.mission03;
        missions.mission04 = data.mission04;
    }
}
