using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public enum WayPointPositions { ofensive = 0, defensive = 1, evasionL = 2, evasionR = 3 };
[RequireComponent(typeof(NavMeshAgent))]
public class MotionModule : MonoBehaviour
{    
    [SerializeField] float m_speed = 3.5f;
    public NavMeshAgent navAgent;    
    
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }
    public float GetStoppingDistance()
    {
        if(navAgent == null)
            navAgent = GetComponent<NavMeshAgent>();

        return navAgent.stoppingDistance;
    }
    public bool IsArrived()
    {
        return navAgent.remainingDistance > navAgent.stoppingDistance ? false : true;
    }
    public void Stop()
    {
        navAgent.speed = 0;
        navAgent.isStopped = true;
    }
    public void FallowTarget(Vector3 pos, float _speed = Mathf.NegativeInfinity)
    {
        if (navAgent.isStopped)
            navAgent.isStopped = false;

        if (_speed == Mathf.NegativeInfinity)
            _speed = m_speed;

        navAgent.speed = _speed;

        SetDestination(pos);
    }
    public void SetDestination(Vector3 pos)
    {                
        navAgent.SetDestination(pos);
    }
}
