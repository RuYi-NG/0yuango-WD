using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateType
{
    Idle, Patrol, Search, Chase, React, Grab
}
//状态类别
[Serializable]
public class Parameter
{
    public float moveSpeed;
    public float chaseSpeed;
    public float idleTime;
    public float searchRange;
    public Transform[] patrolPoints;
    public Transform[] chasePoints;
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
        states.Add(StateType.Search, new SearchState(this));
        states.Add(StateType.Chase, new ChaseState(this));
        states.Add(StateType.React, new ReactState(this));
        states.Add(StateType.Grab, new GrabState(this));

        TransitionState(StateType.Idle);

        parameter.animator = GetComponent<Animator>();
    }
    //注册状态到状态机, 默认状态为Idle, 获取动画控制器

    // Update is called once per frame
    void Update()
    {
        currentState.OnUpdate();
    }
    public void TransitionState(StateType type)
    {
        if (currentState != null)
            currentState.OnExit();
        currentState = states[type];
        currentState.OnEnter();
    }
    //切换状态

    public void FlipTo(Transform target)
    {
        if (target != null)
        {
            if(transform.position.x > target.position.x)
                    {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if(transform.position.x < target.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
    //如有目标，朝向目标
}
