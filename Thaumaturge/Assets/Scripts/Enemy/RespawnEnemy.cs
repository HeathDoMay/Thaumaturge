using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyToSpawn;
    public List<Transform> points;

    public bool canRespawn;
    
    void Awake()
    {
        canRespawn = true;

        //find all patrol points that are children
        int children = transform.childCount;
        Debug.Log(children);
        //points.Length = children;
        for(int i = 0; i < children; i++)
        {
            points.Add(transform.GetChild(i));
            Debug.Log(points[i]);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (canRespawn == true)
        {
            canRespawn = false;
            GameObject newEnemy = Instantiate(enemyToSpawn, SelectPoint().position, Quaternion.identity);

            newEnemy.transform.parent = this.transform.parent.transform;
            newEnemy.transform.GetComponentInChildren<PatrollingEnemyScript>().points = points;
            newEnemy.transform.GetComponentInChildren<PatrollingEnemyScript>().enabled = true;
        }
    }

    private Transform SelectPoint()
    {
        int value = Random.Range(0, points.Count);
        
        Transform respawnPoint = points[value];

        return respawnPoint;
    }
}