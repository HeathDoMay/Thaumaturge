using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPlayer : MonoBehaviour
{
    //Variables that probably don't need to be called from other scripts.
    [SerializeField] private Transform moveToThisObject;
    private NavMeshAgent navMeshAgent;
    [SerializeField] private float stoppingDistance;

    void Awake()
    {
        moveToThisObject = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        bool inLineOfSight = GetComponent<FieldOfView>().canSeePlayer;

        float distanceFromPlayer = Vector2.Distance(moveToThisObject.position, transform.position);

        if(inLineOfSight && distanceFromPlayer > stoppingDistance)
        {
            navMeshAgent.destination = moveToThisObject.position;
        }
        else if(distanceFromPlayer < stoppingDistance)
        {
            navMeshAgent.destination = transform.position;

            //looks at the player to prevent object from rotating unnecessarily when it should be attacking
            Vector3 dir = moveToThisObject.position - transform.position;
            Quaternion lookRot = Quaternion.LookRotation(dir);
            lookRot.x = 0; lookRot.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Mathf.Clamp01(3.0f * Time.maximumDeltaTime));

            if(!inLineOfSight)
            {
                navMeshAgent.destination = moveToThisObject.position;
            }
        }
    }
}