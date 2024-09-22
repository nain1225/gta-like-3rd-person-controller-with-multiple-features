using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("GameObject 01")]
    public GameObject Player;
    public GameObject PoliceCAR;
    public GameObject cam;
    public GameObject Thirdcam;
    public GameObject Aimcam;
    public GameObject CrossHair;
    public GameObject CarAi;
    public GameObject PlayerUI;
    public GameObject miniCamera;
    public GameObject MiniCanvas;
    public GameObject saveCanvas;
    public GameObject PoliceStation;
    public GameObject Boss;
    public GameObject Gangsters;
    public GameObject PoliceOficers;
    public PoliceOfficer01Spawning ps1;
    public PoliceOfficer02Spawning ps2;
    public FbiOfficerSpawning fbi;

    [Header("Scripts")]
    public Player player;

    [Header("GameObject 02")]
    public GameObject cutseenCamera;
    public GameObject CutseenBus;
    public GameObject cutseenPlyer;
    public GameObject rebel01;
    public GameObject rebel02;
    public GameObject BusCollider;
    public GameObject CutseenEndCollider;
    public GameObject cutseen;

    private void Start()
    {
        if (MainMenu.instance.continueGame == true)
        {
            Player.SetActive(true);
            PoliceCAR.SetActive(true);
            cam.SetActive(true);
            Thirdcam.SetActive(true);
            Aimcam.SetActive(true);
            CrossHair.SetActive(true);
            CarAi.SetActive(true);
            PlayerUI.SetActive(true);
            miniCamera.SetActive(true);
            MiniCanvas.SetActive(true);
            saveCanvas.SetActive(true);
            PoliceStation.SetActive(true);
            Boss.SetActive(true);
            Gangsters.SetActive(true);
            PoliceOficers.SetActive(true);
            ps1.GetComponent<PoliceOfficer01Spawning>().enabled = true;
            ps2.GetComponent<PoliceOfficer02Spawning>().enabled = true;
            fbi.GetComponent<FbiOfficerSpawning>().enabled = true;

            //load player
            player.LoadPlayer();

            cutseenCamera.SetActive(false);
            CutseenBus.SetActive(false);
            cutseenPlyer.SetActive(false);
            rebel01.SetActive(false);
            rebel02.SetActive(false);
            BusCollider.SetActive(false);
            CutseenEndCollider.SetActive(false);
            cutseen.SetActive(false);
        }
        if(MainMenu.instance.Startgame == true)
        {
            Player.SetActive(false);
            PoliceCAR.SetActive(false);
            cam.SetActive(false);
            Thirdcam.SetActive(false);
            Aimcam.SetActive(false);
            CrossHair.SetActive(false);
            CarAi.SetActive(false);
            PlayerUI.SetActive(false);
            miniCamera.SetActive(false);
            MiniCanvas.SetActive(false);
            saveCanvas.SetActive(false);
            PoliceStation.SetActive(false);
            Boss.SetActive(false);
            Gangsters.SetActive(false);
            PoliceOficers.SetActive(false);
            ps1.GetComponent<PoliceOfficer01Spawning>().enabled = false;
            ps2.GetComponent<PoliceOfficer02Spawning>().enabled = false;
            fbi.GetComponent<FbiOfficerSpawning>().enabled = false;


            cutseenCamera.SetActive(true);
            CutseenBus.SetActive(true);
            cutseenPlyer.SetActive(false);
            rebel01.SetActive(false);
            rebel02.SetActive(false);
            BusCollider.SetActive(true);
            CutseenEndCollider.SetActive(true);
            cutseen.SetActive(true);
        }
    }
}
