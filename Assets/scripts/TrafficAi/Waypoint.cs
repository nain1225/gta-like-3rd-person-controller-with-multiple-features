using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [Header("Waypoint Status")]
    public Waypoint nextWayPoint;
    public Waypoint previousWaypoint;
    public List<Waypoint> braches = new List<Waypoint>();

    [Range(0f, 1f)]
    public float branchRatio = 0.5f;

    [Range(0f, 5f)]
    public float waypointWidth = 1f;

    public Vector3 GetPosition()
    {
        Vector3 minbound = transform.position + transform.right * waypointWidth / 2f;
        Vector3 maxbound = transform.position - transform.right * waypointWidth / 2f;

        return Vector3.Lerp(minbound, maxbound, Random.Range(0f, 1f));

    }
}
