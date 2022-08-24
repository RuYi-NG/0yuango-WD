using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private FSM manager;
    private Parameter parameter;
    private float timer;

    public IdleState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("Idle");
    }
    public void OnUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= parameter.idleTime)
        {
            manager.TransitionState(StateType.Patrol); //��ʱ���������ô���ʱ�����½���Ѳ��״̬
        }
    }
    public void OnExit()
    {
        timer = 0; //�����ʱ��
    }
}

public class PatrolState : IState
{
    private FSM manager;
    private Parameter parameter;
    private int patrolPosition;

    public PatrolState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("Walk");
    }
    public void OnUpdate()
    {
        manager.FlipTo(parameter.patrolPoints[patrolPosition]); //�泯Ѳ�ߵ�

        manager.transform.position = Vector2.MoveTowards(manager.transform.position, 
            parameter.patrolPoints[patrolPosition].position, parameter.moveSpeed * Time.deltaTime);

        if (Vector2.Distance(manager.transform.position, parameter.patrolPoints[patrolPosition].position)< .1f)
        {
            manager.TransitionState(StateType.Patrol);
        } 
    }
    public void OnExit()
    {
        patrolPosition++; //ǰ�������е���һ��Ѳ�ߵ�

        if(patrolPosition >= parameter.patrolPoints.Length)
        {
            patrolPosition = 0; //�������鷶Χ����Ϊ0��ѭ������һ����
        }
    }
}

public class SearchState : IState
{
    private FSM manager;
    private Parameter parameter;

    public SearchState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {

    }
    public void OnUpdate()
    {

    }
    public void OnExit()
    {

    }
}

public class ChaseState : IState
{
    private FSM manager;
    private Parameter parameter;

    public ChaseState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {

    }
    public void OnUpdate()
    {

    }
    public void OnExit()
    {

    }
}

public class ReactState : IState
{
    private FSM manager;
    private Parameter parameter;

    public ReactState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {

    }
    public void OnUpdate()
    {

    }
    public void OnExit()
    {

    }
}

public class GrabState : IState
{
    private FSM manager;
    private Parameter parameter;

    public GrabState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {

    }
    public void OnUpdate()
    {

    }
    public void OnExit()
    {

    }
}
