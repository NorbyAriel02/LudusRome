using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    public List<Waypoint> waypoints { get; private set; }    
    void Awake()
    {
        waypoints = new List<Waypoint>();
    }
}
