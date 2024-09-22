using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWaypointNavigator : MonoBehaviour
{
    [Header("Car Ai")]
    public CarNavigator car;
    public Waypoint currentWaypoint;

    private void Awake()
    {
        car = GetComponent<CarNavigator>();

    }
    private void Start()
    {
        car.locateDestination(currentWaypoint.GetPosition());

    }
    private void Update()
    {
        if (car.destinationReached)
        {
            currentWaypoint = currentWaypoint.nextWayPoint;
            car.locateDestination(currentWaypoint.GetPosition());

        }
    }
}
