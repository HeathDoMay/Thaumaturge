using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavmeshScript : MonoBehaviour
{
    //Line of Sight needs to be added so enemies don't always chase the player
    //

    //Variables that probably don't need to be called from other scripts.
    [SerializeField] private Transform moveToThisObject;
    [SerializeField] private LayerMask destroyables;
    [SerializeField] private AudioSource audioSource;
    private NavMeshAgent navMeshAgent;
    private float attackAgain;
    private Vector3 previousPosition;
    private float currentSpeed;

    //Variables that will/might need to be called from other scripts.
    public int health;
    public int currentHealth;
    public float attackRange;
    public float attackCooldown;
    public int damage;
    public float volume;

    void Awake()
    {
        currentHealth = health;

        moveToThisObject = GameObject.FindGameObjectWithTag("Player").transform;

        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        navMeshAgent.destination = moveToThisObject.position;
        if (currentHealth <= 0)
        {
            Dead();
        }

        //Currently all the ai does is constantly move towards whatever object it is told to move to
        //and when it has 0 velocity it attacks every time the attackCooldown is up.
        //Eventually the attacking will be much more dynamic depending on the types of enemies we'll have.
        //These will likely be put into their own scripts and this script can be used as a health calculation.
        Vector3 moving = transform.position - previousPosition;
        currentSpeed = moving.magnitude / Time.deltaTime;
        previousPosition = transform.position;

        if (currentSpeed == 0 && attackAgain < Time.time)
        {
            Collider[] objectsToHit = Physics.OverlapSphere(this.transform.position, attackRange, destroyables);
            foreach (Collider destroyableObject in objectsToHit)
            {
                OnTriggerEnter(destroyableObject);
            }
            attackAgain = Time.time + attackCooldown;
        }
    }

    //destroys object
    //Change this later on to despawn after 30 seconds to a minute or more to give player time to siphon powers
    private void Dead()
    {
        Destroy(gameObject, 1f);
        //Destroy(gameObject, 120f);
    }

    //call this method when enemy is supposed to lose health
    public void LoseHealth(int dmg)
    {
        //audioSource.PlayOneShot(audioSource.clip, volume);
        currentHealth -= dmg;
    }

    //calls health scripts on whatever object gets hit
    private void OnTriggerEnter(Collider other)
    {
        /*
        if (other.TryGetComponent(out DefendObject health))
        {
            health.LoseHealth(damage);
        }
        if (other.TryGetComponent(out Wall wallHealth))
        {
            wallHealth.LoseHealth(damage);
        }*/
    }

    //shows attack range
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, attackRange);
    }
}
