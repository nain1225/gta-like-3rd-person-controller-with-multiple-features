using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCount : MonoBehaviour
{
    public Text ammotext;
    public Text magtext;
    public static AmmoCount instance;

    private void Awake()
    {
        instance = this;
    }
    public void UpdateAmmoCount(int amomo)
    {
        ammotext.text = "" + amomo;
    }
    public void UpdateMagCount(int mag)
    {
        magtext.text = "" + mag;
    }
}
