using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusCollider : MonoBehaviour
{
    public GameObject cutseenPlyer;
    public GameObject rebel01;
    public GameObject rebel02;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bus")
        {
            cutseenPlyer.SetActive(true);
            rebel01.SetActive(true);
            rebel02.SetActive(true);
        }

    }
}
