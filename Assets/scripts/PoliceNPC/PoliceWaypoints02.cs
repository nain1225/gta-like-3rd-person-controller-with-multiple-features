using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceWaypoints02 : MonoBehaviour
{
    public PoliceOfficer02 character;
    public Waypoint currentWaypoint;
    private int direction;

    private void Awake()
    {
        character = GetComponent<PoliceOfficer02>();
    }
    private void Start()
    {
        direction = Mathf.RoundToInt(Random.Range(0f, 1f));
        character.locateDestination(currentWaypoint.GetPosition());
    }
    private void Update()
    {
        if (character.isdestinationReached)
        {
            bool shouldBranch = false;
            if (currentWaypoint.braches != null && currentWaypoint.braches.Count > 0)
            {
                shouldBranch = Random.Range(0f, 1f) <= currentWaypoint.branchRatio ? true : false;
            }
            if (shouldBranch)
            {
                currentWaypoint = currentWaypoint.braches[Random.Range(0, currentWaypoint.braches.Count - 1)];
            }
            else
            {
                if (direction == 0)
                {
                    if (currentWaypoint.nextWayPoint != null)
                    {
                        currentWaypoint = currentWaypoint.nextWayPoint;
                    }
                    else
                    {
                        currentWaypoint = currentWaypoint.previousWaypoint;
                        direction = 1;
                    }
                }
                else if (direction == 1)
                {
                    if (currentWaypoint.previousWaypoint != null)
                    {
                        currentWaypoint = currentWaypoint.previousWaypoint;
                    }
                    else
                    {
                        currentWaypoint = currentWaypoint.nextWayPoint;
                        direction = 0;
                    }
                }
            }

            character.locateDestination(currentWaypoint.GetPosition());
        }
    }
}
