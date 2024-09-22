using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class item
{
    public string name;
    public GameObject weapon;
    public bool ispicked = false;
    public bool isactive = false;
}

public class Inventory : MonoBehaviour
{
    [Header("Item Slots")]
    public GameObject Weapon1;
    public bool isWeapon1Picked = false;
    public bool isWeapon1Active = false;

    public GameObject Weapon2;
    public bool isWeapon2Picked = false;
    public bool isWeapon2Active = false;

    public GameObject Weapon3;
    public bool isWeapon3Picked = false;
    public bool isWeapon3Active = false;

    public GameObject Weapon4;
    public bool isWeapon4Picked = false;
    public bool isWeapon4Active = false;

    /*[Header("Weapon to use")]
    public GameObject[] UsedWeapons; //= new GameObject[4];*/

    /*[Header("Item Slots")]
    public List<item> items = new List<item>();*/

    [Header("Weapon to use")]
    public GameObject HandGun;
    public GameObject HandGun2;
    public GameObject ShotGun;
    public GameObject UziGun;
    public GameObject UziGun2;
    public GameObject Bazooka;

    [Header("Scrips to use")]
    public player_controller_script playerScript;
    public handGun handGunScript;
    public HandGun2 handGun2Script;
    public ShotGun shotGunScript;
    public UziGun uziGunScript;
    public UziGun2 UziGun2Script;
    public Bazooka BazookaScript;

    [Header("Inventory")]
    public GameObject inventory;
    bool isPause = false;
    public SwitchCamera SwitchCamera;
    public GameObject Aimcam;
    public GameObject ThirdPersonCam;

    private void Update()
    {
        if (Input.GetKeyDown("1") && isWeapon1Picked==true)
        {
            isWeapon1Active = true;
            isWeapon2Active = false;
            isWeapon3Active = false;
            isWeapon4Active = false;
            IsRifleActive();
        }
        else if (Input.GetKeyDown("2") && isWeapon2Picked == true)
        {
            isWeapon1Active = false;
            isWeapon2Active = true;
            isWeapon3Active = false;
            isWeapon4Active = false;
            IsRifleActive();

        }
        else if (Input.GetKeyDown("3") && isWeapon3Picked == true)
        {
            isWeapon1Active = false;
            isWeapon2Active = false;
            isWeapon3Active = true;
            isWeapon4Active = false;
            IsRifleActive();

        }
        else if (Input.GetKeyDown("4") && isWeapon4Picked == true)
        {
            isWeapon1Active = false;
            isWeapon2Active = false;
            isWeapon3Active = false;
            isWeapon4Active = true;
            IsRifleActive();

        }
        else if (Input.GetKeyDown("tab"))
        {
            if (isPause)
            {
                hideInventory();
            }
            else
            {
                if(isWeapon1Picked == true)
                {
                    Weapon1.SetActive(true);
                }
                if (isWeapon2Picked == true)
                {
                    Weapon2.SetActive(true);
                }
                if (isWeapon3Picked == true)
                {
                    Weapon3.SetActive(true);
                }
                if (isWeapon4Picked == true)
                {
                    Weapon4.SetActive(true);
                }
                showInventory();
            }
        }
    }

    void IsRifleActive()
    {
        if (isWeapon1Active == true)
        {
            HandGun.SetActive(true);
            HandGun2.SetActive(true);
            ShotGun.SetActive(false);
            UziGun.SetActive(false);
            UziGun2.SetActive(false);
            Bazooka.SetActive(false);

            playerScript.GetComponent<player_controller_script>().enabled = false;
            handGunScript.GetComponent<handGun>().enabled = true;
            handGun2Script.GetComponent<HandGun2>().enabled = true;
            shotGunScript.GetComponent<ShotGun>().enabled = false;
            uziGunScript.GetComponent<UziGun>().enabled = false;
            UziGun2Script.GetComponent<UziGun2>().enabled = false;
            BazookaScript.GetComponent<Bazooka>().enabled = false;
        }
        else if (isWeapon2Active == true)
        {
            HandGun.SetActive(false);
            HandGun2.SetActive(false);
            ShotGun.SetActive(true);
            UziGun.SetActive(false);
            UziGun2.SetActive(false);
            Bazooka.SetActive(false);

            playerScript.GetComponent<player_controller_script>().enabled = false;
            handGunScript.GetComponent<handGun>().enabled = false;
            handGun2Script.GetComponent<HandGun2>().enabled = false;
            shotGunScript.GetComponent<ShotGun>().enabled = true;
            uziGunScript.GetComponent<UziGun>().enabled = false;
            UziGun2Script.GetComponent<UziGun2>().enabled = false;
            BazookaScript.GetComponent<Bazooka>().enabled = false;

        }
        else if(isWeapon3Active == true)
        {
            HandGun.SetActive(false);
            HandGun2.SetActive(false);
            ShotGun.SetActive(false);
            UziGun.SetActive(true);
            UziGun2.SetActive(true);
            Bazooka.SetActive(false);

            playerScript.GetComponent<player_controller_script>().enabled = false;
            handGunScript.GetComponent<handGun>().enabled = false;
            handGun2Script.GetComponent<HandGun2>().enabled = false;
            shotGunScript.GetComponent<ShotGun>().enabled = false;
            uziGunScript.GetComponent<UziGun>().enabled = true;
            UziGun2Script.GetComponent<UziGun2>().enabled = true;
            BazookaScript.GetComponent<Bazooka>().enabled = false;

        }
        else if (isWeapon4Active == true)
        {
            HandGun.SetActive(false);
            HandGun2.SetActive(false);
            ShotGun.SetActive(false);
            UziGun.SetActive(false);
            UziGun2.SetActive(false);
            Bazooka.SetActive(true);

            playerScript.GetComponent<player_controller_script>().enabled = false;
            handGunScript.GetComponent<handGun>().enabled = false;
            handGun2Script.GetComponent<HandGun2>().enabled = false;
            shotGunScript.GetComponent<ShotGun>().enabled = false;
            uziGunScript.GetComponent<UziGun>().enabled = false;
            UziGun2Script.GetComponent<UziGun2>().enabled = false;
            BazookaScript.GetComponent<Bazooka>().enabled = true;

        }
    }
    void showInventory()
    {
        SwitchCamera.GetComponent<SwitchCamera>().enabled=false;
        Aimcam.SetActive(false);
        ThirdPersonCam.SetActive(false);

        inventory.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
    }
    void hideInventory()
    {
        SwitchCamera.GetComponent<SwitchCamera>().enabled = true;
        Aimcam.SetActive(true);
        ThirdPersonCam.SetActive(true);

        inventory.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
    }
}
