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
        if(parameter.target != null)
        {
            manager.TransitionState(StateType.Chase);
        }
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

        if (parameter.target != null)
        {
            manager.TransitionState(StateType.Chase);
        }

        if (Vector2.Distance(manager.transform.position, parameter.patrolPoints[patrolPosition].position)< .1f)
        {
            manager.TransitionState(StateType.Idle);
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

public class ChaseState : IState
{
    private FSM manager;
    private Parameter parameter;
    private float timer;

    public ChaseState(FSM manager)
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
        manager.FlipTo(parameter.target);
        if (parameter.target)
        {
            manager.transform.position = Vector2.MoveTowards(manager.transform.position,
                parameter.target.position, parameter.chaseSpeed * Time.deltaTime);
            //׷��Ŀ��
        }
        if(Physics2D.OverlapCircle(parameter.attackPoint.position, parameter.attackArea, parameter.targetLayer))
        {
            manager.TransitionState(StateType.Attack);
        }
        //�����ж���Χ������غ�ʱ�л�������״̬
    }
    public void OnExit()
    {

    }
}

public class ReactState : IState
{
    private FSM manager;
    private Parameter parameter;
    private AnimatorStateInfo info;

    public ReactState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("React");
    }
    public void OnUpdate()
    {
        info = parameter.animator.GetCurrentAnimatorStateInfo(0);
        // if (info.normalizedTime >= .95f)
        manager.TransitionState(StateType.Chase);

    }
    public void OnExit()
    {

    }
}

public class AttackState : IState
{
    private FSM manager;
    private Parameter parameter;
    private AnimatorStateInfo info;

    public AttackState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    public void OnEnter()
    {
        parameter.animator.Play("Attack");
    }
    public void OnUpdate()
    {
        // info = parameter.animator.GetCurrentAnimatorStateInfo(0);
        // if(info.normalizedTime >= .95f)
        manager.TransitionState(StateType.Idle);
    }
    public void OnExit()
    {

    }
}
