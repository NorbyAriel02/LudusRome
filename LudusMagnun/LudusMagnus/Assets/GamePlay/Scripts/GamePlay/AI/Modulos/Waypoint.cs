using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    WaypointManager m_waypointManager;
    void Start()
    {
        m_waypointManager = GameObject.FindObjectOfType<WaypointManager>();
        if (!m_waypointManager.waypoints.Contains(this))
        {
            m_waypointManager.waypoints.Add(this);
        }
    }
    void OnDestroy()
    {
        // Unregister as an actor
        if (m_waypointManager)
        {
            m_waypointManager.waypoints.Remove(this);
        }
    }
}
