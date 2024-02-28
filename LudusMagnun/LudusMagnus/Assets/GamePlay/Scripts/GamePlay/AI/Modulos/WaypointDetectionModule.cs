using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointDetectionModule : MonoBehaviour
{    
    public Transform DetectionSourcePoint;

    [Tooltip("The max distance at which the waypoint can see targets")]
    public float DetectionRange = 20f;
    
    public List<Transform> KnownDetectedWayPoints;
    WaypointManager m_WaypointsManager;

    protected void Start()
    {
        m_WaypointsManager = FindObjectOfType<WaypointManager>();
    }

    public void HandleWaypointDetection()
    {
        KnownDetectedWayPoints = new List<Transform>();
        // Find the closest visible hostile actor
        float sqrDetectionRange = DetectionRange * DetectionRange;            
        foreach (Waypoint waypoint in m_WaypointsManager.waypoints)
        {
            float sqrDistance = (waypoint.transform.position - DetectionSourcePoint.position).sqrMagnitude;
            if (sqrDistance < sqrDetectionRange)
            {
                KnownDetectedWayPoints.Add(waypoint.gameObject.transform);
            }
        }
    }   
}
