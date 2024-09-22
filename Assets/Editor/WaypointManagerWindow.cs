using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WaypointManagerWindow : EditorWindow
{
   [MenuItem("Waypoints/Waypoint Tools/HASNAIN Tools")]

   public static void ShowWindow()
    {
        GetWindow<WaypointManagerWindow>("Waypoint Tools Editor");
    }
    public Transform WaypointOrign;
    private void OnGUI()
    {
        SerializedObject obj = new SerializedObject(this);
        EditorGUILayout.PropertyField(obj.FindProperty("WaypointOrign"));
        if (WaypointOrign == null)
        {
            EditorGUILayout.HelpBox("please assign a waypoint orign transform", MessageType.Warning);
        }
        else
        {
            EditorGUILayout.BeginVertical("box");
            CreateButton();
            EditorGUILayout.EndVertical();
        }
        obj.ApplyModifiedProperties();
    }
    void CreateButton()
    {
        if(GUILayout.Button("Create Button"))
        {
            CeateWaypoint();
        }
        if(Selection.activeGameObject !=null && Selection.activeGameObject.GetComponent<Waypoint>())
        {
            if (GUILayout.Button("Create waypoint Before"))
            {
                CeateWaypointBefore();
            }
            if (GUILayout.Button("Create waypoint After"))
            {
                CeateWaypointAfter();
            }
            if (GUILayout.Button("Create waypoint Branch"))
            {
                CeateWaypointBranch();
            }
            if (GUILayout.Button("Remove Waypoint"))
            {
                RemoveWaypoint();
            }
        } 
    }
    void CeateWaypoint()
    {
        GameObject waypointobject = new GameObject("Waypoint" + WaypointOrign.childCount, typeof(Waypoint));
        waypointobject.transform.SetParent(WaypointOrign, false);

        Waypoint waypoint = waypointobject.GetComponent<Waypoint>();

        if(WaypointOrign.childCount > 1)
        {
            waypoint.previousWaypoint = WaypointOrign.GetChild(WaypointOrign.childCount - 2).GetComponent<Waypoint>();
            waypoint.previousWaypoint.nextWayPoint = waypoint;

            waypoint.transform.position = waypoint.previousWaypoint.transform.position;
            waypoint.transform.forward = waypoint.previousWaypoint.transform.forward;
        }
        Selection.activeGameObject = waypoint.gameObject;
    }
    void CeateWaypointBefore()
    {
        GameObject waypointobject = new GameObject("Waypoint" + WaypointOrign.childCount, typeof(Waypoint));
        waypointobject.transform.SetParent(WaypointOrign, false);

        Waypoint newwaypoint = waypointobject.GetComponent<Waypoint>();
        Waypoint SelectedWaypoint = Selection.activeGameObject.GetComponent<Waypoint>();

        waypointobject.transform.position = SelectedWaypoint.transform.position;
        waypointobject.transform.position = SelectedWaypoint.transform.forward;

        if (SelectedWaypoint.previousWaypoint)
        {
            newwaypoint.previousWaypoint = SelectedWaypoint.previousWaypoint;
            SelectedWaypoint.previousWaypoint.nextWayPoint = newwaypoint;
        }
        newwaypoint.nextWayPoint = SelectedWaypoint;
        SelectedWaypoint.previousWaypoint = newwaypoint;

        newwaypoint.transform.SetSiblingIndex(SelectedWaypoint.transform.GetSiblingIndex());
        Selection.activeGameObject = newwaypoint.gameObject;
    }
    void CeateWaypointAfter()
    {
        GameObject waypointobject = new GameObject("Waypoint" + WaypointOrign.childCount, typeof(Waypoint));
        waypointobject.transform.SetParent(WaypointOrign, false);

        Waypoint newwaypoint = waypointobject.GetComponent<Waypoint>();
        Waypoint SelectedWaypoint = Selection.activeGameObject.GetComponent<Waypoint>();

        waypointobject.transform.position = SelectedWaypoint.transform.position;
        waypointobject.transform.position = SelectedWaypoint.transform.forward;
        if(SelectedWaypoint.nextWayPoint != null)
        {
            SelectedWaypoint.nextWayPoint.previousWaypoint = newwaypoint;
            newwaypoint.nextWayPoint = SelectedWaypoint.previousWaypoint;
        }
        SelectedWaypoint.nextWayPoint = newwaypoint;

        newwaypoint.transform.SetSiblingIndex(SelectedWaypoint.transform.GetSiblingIndex());
        Selection.activeGameObject = newwaypoint.gameObject;
    }

    void CeateWaypointBranch()
    {
        GameObject waypointobject = new GameObject("Waypoint" + WaypointOrign.childCount, typeof(Waypoint));
        waypointobject.transform.SetParent(WaypointOrign, false);

        Waypoint waypoint = waypointobject.GetComponent<Waypoint>();
        Waypoint brachFrom = Selection.activeGameObject.GetComponent<Waypoint>();
        brachFrom.braches.Add(waypoint);

        waypoint.transform.position = brachFrom.transform.position;
        waypoint.transform.forward = brachFrom.transform.forward;

        Selection.activeGameObject = waypoint.gameObject;
    }
    void RemoveWaypoint()
    {
        Waypoint SelectedWaypoint = Selection.activeGameObject.GetComponent<Waypoint>();
        if (SelectedWaypoint.nextWayPoint!=null)
        {
            SelectedWaypoint.nextWayPoint.previousWaypoint = SelectedWaypoint.previousWaypoint;
        }
        if (SelectedWaypoint.previousWaypoint != null)
        {
            SelectedWaypoint.previousWaypoint.nextWayPoint = SelectedWaypoint.nextWayPoint;
            Selection.activeGameObject = SelectedWaypoint.previousWaypoint.gameObject;

            DestroyImmediate(SelectedWaypoint.gameObject);
        }

    }

}
