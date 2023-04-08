using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPlayer : MonoBehaviour
{
    //Variables that probably don't need to be called from other scripts.
    [SerializeField] private Transform moveToThisObject;
    private NavMeshAgent navMeshAgent;

    void Awake()
    {
        moveToThisObject = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        bool inLineOfSight = GetComponent<FieldOfView>().canSeePlayer;

        if(inLineOfSight)
        {
            navMeshAgent.destination = moveToThisObject.position;
        }
    }
}