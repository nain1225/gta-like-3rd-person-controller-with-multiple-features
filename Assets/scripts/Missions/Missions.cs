using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Missions : MonoBehaviour
{
    public bool mission01;
    public bool mission02;
    public bool mission03;
    public bool mission04;

    public Text MissionText;

    private void Update()
    {
        if(mission01==false && mission02 == false && mission03 == false && mission04 == false)
        {
            //Ui
            MissionText.text = ("Load and save the game in the player house");
        }
        if (mission01 == true && mission02 == false && mission03 == false && mission04 == false)
        {
            //Ui
            MissionText.text = ("Meet Franklin in the police station");
        }
        if (mission01 == true && mission02 == true && mission03 == false && mission04 == false)
        {
            //Ui
            MissionText.text = ("Find weapons in the house");
        }
        if (mission01 == true && mission02 == true && mission03 == true && mission04 == false)
        {
            //Ui
            MissionText.text = ("Take revenge and kill the mafia boss");
        }
        if (mission01 == true && mission02 == true && mission03 == true && mission04 == true)
        {
            //Ui
            MissionText.text = ("All missions are completed");
        }
    }
}
