using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [Header("Item Info")]
    public int ItemPrice;
    public int ItemRadius;
    public string ItemTag;
    private GameObject ItemToPick;

    [Header("Player Info")]
    public Player player;
    public Inventory Inventory;
    public Missions mission;

    private void Start()
    {
        ItemToPick = GameObject.FindWithTag(ItemTag);
    }
    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < ItemRadius)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (player.PlayerMoney < ItemPrice)
                {
                    Debug.Log("you are out of money");
                }
                else
                {
                    if (mission.mission01 == true && mission.mission02 == true && mission.mission04 == false)
                    {
                        mission.mission03 = true;
                        player.PlayerMoney += 500;
                    }
                    if (ItemTag == "HandGun")
                    {
                        player.PlayerMoney -= ItemPrice;
                        Inventory.Weapon1.SetActive(true);
                        Inventory.isWeapon1Picked = true;
                        Debug.Log(ItemTag);
                    }
                    else if(ItemTag == "ShotGun")
                    {
                        player.PlayerMoney -= ItemPrice;
                        Inventory.Weapon2.SetActive(true);
                        Inventory.isWeapon2Picked = true;
                        Debug.Log(ItemTag);
                    }
                    else if (ItemTag == "UziGun")
                    {
                        player.PlayerMoney -= ItemPrice;
                        Inventory.Weapon3.SetActive(true);
                        Inventory.isWeapon3Picked = true;
                        Debug.Log(ItemTag);
                    }
                    else if (ItemTag == "Bazooka")
                    {
                        player.PlayerMoney -= ItemPrice;
                        Inventory.Weapon4.SetActive(true);
                        Inventory.isWeapon4Picked = true;
                        Debug.Log(ItemTag);
                    }

                    ItemToPick.SetActive(false);
                    
                }
            }
        }
    }
}
