using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalMoveTest : MonoBehaviour
{
    [SerializeField] private Transform target;
    
    private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
    }

    private void Update()
    {
        _navMeshAgent.SetDestination(target.position);
    }
}
