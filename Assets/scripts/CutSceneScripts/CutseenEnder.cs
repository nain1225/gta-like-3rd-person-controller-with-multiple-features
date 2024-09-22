using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutseenEnder : MonoBehaviour
{
    [Header("Activated things after cutscene")]
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

    [Header("Deativated things after cutscene")]
    public GameObject cutseenCamera;
    public GameObject CutseenBus;
    public GameObject cutseenPlyer;
    public GameObject rebel01;
    public GameObject rebel02;
    public GameObject BusCollider;
    public GameObject CutseenEndCollider;
    public GameObject cutseen;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "CutseenCamera")
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


            cutseenCamera.SetActive(false);
            CutseenBus.SetActive(false);
            cutseenPlyer.SetActive(false);
            rebel01.SetActive(false);
            rebel02.SetActive(false);
            BusCollider.SetActive(false);
            CutseenEndCollider.SetActive(false);
            cutseen.SetActive(false);

        }
    }
}
