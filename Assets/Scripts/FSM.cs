using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateType
{
    Idle, Patrol, Chase, React, Attack, Search
}
//状态类别
[Serializable]
public class Parameter
{
    public float patrolSpeed;
    public float searchSpeed;
    public float chaseSpeed;
    public float idleTime;
    public Transform[] patrolPoints;
    public Transform[] chasePoints;
    public Transform target;
    public LayerMask targetLayer;
    public Transform attackPoint;
    public float attackArea;
    public float attackDamage;
    public Animator animator;
}
public class FSM : MonoBehaviour
{
    public Parameter parameter;

    private IState currentState;

    private Dictionary<StateType, IState> states = new Dictionary<StateType, IState>();

    void Start()
    {
        states.Add(StateType.Idle, new IdleState(this));
        states.Add(StateType.Patrol, new PatrolState(this));
        states.Add(StateType.Chase, new ChaseState(this));
        states.Add(StateType.React, new ReactState(this));
        states.Add(StateType.Attack, new AttackState(this));
        states.Add(StateType.Search, new SearchState(this));

        TransitionState(StateType.Patrol);

        parameter.animator = GetComponent<Animator>();
    }
    //注册状态到状态机， 默认状态为Patrol， 获取动画控制器

    // Update is called once per frame
    void Update()
    {
        currentState.OnUpdate();
    }
    public void TransitionState(StateType type)
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }
        currentState = states[type];
        currentState.OnEnter();
    }
    //切换状态

    public void FlipTo(Transform target)
    {
        float Scalex = Mathf.Abs(gameObject.transform.localScale.x);
        if (target != null)
        {
            if(transform.position.x > target.position.x)
            {
                transform.localScale = new Vector3(Scalex * -1, gameObject.transform.localScale.y * 1, gameObject.transform.localScale.z * 1);
            }
            else if(transform.position.x < target.position.x)
            {
                transform.localScale = new Vector3(Scalex * 1, gameObject.transform.localScale.y * 1, gameObject.transform.localScale.z * 1);
            }
        }
    }
    //如有目标，朝向目标
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            {
            parameter.target = other.transform;
            }
    }
    //视线中如有玩家，玩家变为目标

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            parameter.target = null;
        }
    }
    //视线中丢失玩家，失去目标
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(parameter.attackPoint.position, parameter.attackArea);
    }
}
