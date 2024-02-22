using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class MotionModule : MonoBehaviour
{
    private NavMeshAgent navAgent;    
    private List<Transform> waypoints;
    void Start()
    {
        waypoints = ChildrenController.GetTransformChildrenWithTag(gameObject, "Waypoint");
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.SetDestination(waypoints[0].position);
    }
    
    public void SetDestination(int indexWayPoint)
    {
        navAgent.SetDestination(waypoints[indexWayPoint].position);
    }
}
