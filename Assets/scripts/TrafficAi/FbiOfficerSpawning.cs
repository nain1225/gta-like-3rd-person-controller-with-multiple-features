using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FbiOfficerSpawning : MonoBehaviour
{
    public GameObject[] AiPrefabs;
    public int AitoSpawn;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        int count = 0;
        while (count < AitoSpawn)
        {
            int randomIndex = Random.Range(0, AiPrefabs.Length);
            GameObject obj = Instantiate(AiPrefabs[randomIndex]);

            //get random waypoint for ai characters
            Transform child = transform.GetChild(Random.Range(0, transform.childCount - 1));
            obj.GetComponent<FBIOfficerWaypoints>().currentWaypoint = child.GetComponent<Waypoint>();

            obj.transform.position = child.position;

            yield return new WaitForSeconds(1f);

            count++;
        }
    }
}
