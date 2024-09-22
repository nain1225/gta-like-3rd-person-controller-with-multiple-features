using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour
{
    public Player player;
    public Text MoneyAmount;

    private void Update()
    {
        MoneyAmount.text = "" + player.PlayerMoney;
    }
}
