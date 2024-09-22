/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad()]
public class WaypointEditor 
{
    [DrawGizmo(GizmoType.NonSelected|GizmoType.Selected|GizmoType.Pickable)]
   public static void onDrawGizmoz(Waypoint waypoint,GizmoType gizmoType)
    {
        if ((gizmoType & GizmoType.Selected)!=0)
        {
            Gizmos.color = Color.blue;
        }
        else
        {
            Gizmos.color = Color.blue * 0.5f;
        }
        Gizmos.DrawSphere(waypoint.transform.position, 0.1f);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(waypoint.transform.position+(waypoint.transform.right * waypoint.waypointWidth/2f),waypoint.transform.position-(waypoint.transform.right*waypoint.waypointWidth/2f));

        if (waypoint.previousWaypoint != null)
        {
            Gizmos.color = Color.red;

            Vector3 offset = waypoint.transform.position * waypoint.waypointWidth / 2f;
            Vector3 offsetTo = waypoint.previousWaypoint.transform.right * waypoint.previousWaypoint.waypointWidth / 2f;

            Gizmos.DrawLine(waypoint.transform.position + offset, waypoint.previousWaypoint.transform.position + offsetTo);
        }
        if (waypoint.nextWayPoint != null)
        {
            Gizmos.color = Color.green;

            Vector3 offset = waypoint.transform.position * -waypoint.waypointWidth / 2f;
            Vector3 offsetTo = waypoint.previousWaypoint.transform.right * -waypoint.previousWaypoint.waypointWidth / 2f;

            Gizmos.DrawLine(waypoint.transform.position + offset, waypoint.previousWaypoint.transform.position + offsetTo);
        }
    }
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad()]
public class WaypointEditor
{
    [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected | GizmoType.Pickable)]
    public static void onDrawGizmoz(Waypoint waypoint, GizmoType gizmoType)
    {
        if ((gizmoType & GizmoType.Selected) != 0)
        {
            Gizmos.color = Color.blue;
        }
        else
        {
            Gizmos.color = Color.blue * 0.5f;
        }
        Gizmos.DrawSphere(waypoint.transform.position, 0.1f);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(waypoint.transform.position + (waypoint.transform.right * waypoint.waypointWidth / 2f),
                        waypoint.transform.position - (waypoint.transform.right * waypoint.waypointWidth / 2f));

        if (waypoint.previousWaypoint != null)
        {
            Gizmos.color = Color.red;

            Vector3 offset = waypoint.transform.right * waypoint.waypointWidth / 2f;
            Vector3 offsetTo = waypoint.previousWaypoint.transform.right * waypoint.previousWaypoint.waypointWidth / 2f;

            Gizmos.DrawLine(waypoint.transform.position + offset, waypoint.previousWaypoint.transform.position + offsetTo);
        }
        if (waypoint.nextWayPoint != null)
        {
            Gizmos.color = Color.green;

            Vector3 offset = waypoint.transform.right * -waypoint.waypointWidth / 2f;
            Vector3 offsetTo = waypoint.nextWayPoint.transform.right * -waypoint.nextWayPoint.waypointWidth / 2f;

            Gizmos.DrawLine(waypoint.transform.position + offset, waypoint.nextWayPoint.transform.position + offsetTo);
        }

        if (waypoint.braches != null)
        {
            foreach (Waypoint branch in waypoint.braches)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(waypoint.transform.position, branch.transform.position);
            }
        }
    }
}