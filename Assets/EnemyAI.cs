using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


// 3 State enemy AI, patrolling, chasing, attacking
public class EnemyAI : MonoBehaviour
{
    public float health;

    public NavMeshAgent agent;

    public Transform player_transform;

    public LayerMask layer_ground, layer_player;

    // Patrolling variables
    public Vector3 walk_point;
    bool point_set;
    public float walk_point_range;

    // Attacking
    public float attack_rate;
    bool attack_cooldown;
    public GameObject projectile;

    // States
    public float sight_range, attack_range;
    public bool player_seen, player_in_range;

    // Set these variables on game start.
    private void Awake()
    {
        player_transform = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Patrolling()
    {
        if (!point_set)
        {
            SearchWalkPoint();
        }
        
        if (point_set)
        {
            agent.SetDestination(walk_point);
        }

        Vector3 distance_to_point = transform.position - walk_point;
        
        // If the distance is less than one, patrol point reached. Set a new point.
        if (distance_to_point.magnitude < 1.0f)
        {
            point_set = false;
        }
    }
    private void SearchWalkPoint()
    {
        // Random points in range for X and Z axis (Y axis stays same)
        float point_x = Random.Range(-walk_point_range, walk_point_range);
        float point_z = Random.Range(-walk_point_range, walk_point_range);
        
        // Set the walk point vector
        walk_point = new Vector3(transform.position.x + point_x, transform.position.y, transform.position.z + point_z);

        // Raycast to see if the point is actually on the map
        // origin at walk_point, point down to ground (-transform.up), 2f distance to check, checking ground layermask
        if (Physics.Raycast(walk_point, -transform.up, 2f, layer_ground))
        {
            point_set = true;
        }
    }

    private void Chasing()
    {
        agent.SetDestination(player_transform.position);
    }

    private void AttackPlayer()
    {
        // Enemy won't move during attack
        agent.SetDestination(transform.position);

        transform.LookAt(player_transform);
    }

    private void ResetAttack()
    {
        if (!attack_cooldown)
        {
            // Attack code here
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32.0f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8.0f, ForceMode.Impulse);
            attack_cooldown = true;
            Invoke(nameof(ResetAttack), attack_rate);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check to see if the player is in vision
        player_seen = Physics.CheckSphere(transform.position, sight_range, layer_player);
        // Check to see if the player is in attack range
        player_in_range = Physics.CheckSphere(transform.position, attack_range, layer_player);
        
        // If enemy cannot see you, keep patrolling
        if (!player_seen && !player_in_range)
        {
            Patrolling();
        }
        // If enemy can see you but you are not in range, chase.
        if (player_seen && !player_in_range)
        {
            Chasing();
        }
        // If you are seen and in range, attack.
        if (player_seen && player_in_range)
        {
            AttackPlayer();
        }
    }

    public void TakeDamage (float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Invoke(nameof(DestoryEnemy), .5f);
        }
    }
    
    private void DestoryEnemy()
    {
        Destroy(gameObject);
    }
}
