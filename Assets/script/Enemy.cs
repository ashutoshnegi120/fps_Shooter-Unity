using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] NavMeshAgent enemy;
    [SerializeField] Transform Player;
    [SerializeField] LayerMask GroundMask,playerMask;

//timePass
    [SerializeField] Vector3 WalkPoint;
    [SerializeField] bool WalkPointIsSet;
    [SerializeField] float WalkPointRange;
//attack

    [SerializeField] float TimeBwAttack;
    [SerializeField] bool Attacked;

//status

    [SerializeField] float sightRange,AttackRange;
    [SerializeField] bool PlayerINSightRange,PlayerINAttackRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        enemy =  GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        //check for attack range and sight range

        PlayerINSightRange = Physics.CheckSphere(transform.position,sightRange,playerMask);
        PlayerINAttackRange = Physics.CheckSphere(transform.position,AttackRange,playerMask);

        if( !PlayerINSightRange && !PlayerINAttackRange) Patrolling();
        if( PlayerINSightRange && !PlayerINAttackRange) ChasePlayer();
        if( PlayerINAttackRange && PlayerINSightRange) Attack();
        
    }

    private void Patrolling()
    {
        if(!WalkPointIsSet) SetWalkPoint();
        enemy.SetDestination(WalkPoint);

        Vector3 DistanceFromDestination = WalkPoint - transform.position;

        if(DistanceFromDestination.magnitude < 1f)
        {
            WalkPointIsSet = false;
        }
    }

    private void SetWalkPoint()
    {
        float RandomX = UnityEngine.Random.Range(-WalkPointRange,WalkPointRange);
        float RandomZ = UnityEngine.Random.Range(-WalkPointRange,WalkPointRange);

        WalkPoint = new Vector3(transform.position.x + RandomX, transform.position.y, transform.position.z + RandomZ);

        if(Physics.Raycast(WalkPoint,-transform.up,4f,GroundMask))
        {
            WalkPointIsSet = true;
        }
    }

    private void ChasePlayer()
    {
        enemy.SetDestination(Player.position);
    }
    private void Attack()
    {

        enemy.SetDestination(transform.position);
        transform.LookAt(Player);

        if(!Attacked)
        {
            Attacked = true;
            Invoke(nameof(ResetAttack),TimeBwAttack);
        }

    }
    private void ResetAttack()
    {
        Attacked  = false;
    }
   
}
