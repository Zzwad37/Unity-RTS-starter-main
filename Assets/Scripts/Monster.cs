using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Monster : MonoBehaviour
{
    
    //3 states: Patrolling, Moving, Attacking
    //Moving overrides patrolling and attacking.
    
    private Animator myAnimator;
    private NavMeshAgent ai;

    private const int IdleAnims = 2;

    [SerializeField] private float maxHealth;
    private float health;
    
    
    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        ai = GetComponent<NavMeshAgent>();
        health = maxHealth;
    }

    private void Update()
    {
        Vector3 velocity = transform.InverseTransformVector(ai.velocity);
        
        myAnimator.SetFloat(StaticUtilities.XSpeedAnimId, velocity.x);
        myAnimator.SetFloat(StaticUtilities.YSpeedAnimId, velocity.z);
    }

    public void MoveToTarget(Vector3 hitInfoPoint)
    {
        ai.SetDestination(hitInfoPoint);
    }

    public void ChangeIdleState()
    {
        int rngIndex = Random.Range(0, 2);
        myAnimator.SetFloat(StaticUtilities.IdleAnimId, rngIndex);
    }
    

}
