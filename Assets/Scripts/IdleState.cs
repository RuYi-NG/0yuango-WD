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
            manager.TransitionState(StateType.Search); //计时器大于设置待机时间重新进入搜索状态
        }
    }
    public void OnExit()
    {
        timer = 0; //清除计时器
    }
}

public class PatrolState : IState
{
    private FSM manager;
    private Parameter parameter;
    private int patrolPosition;
    private float timer;

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
        manager.FlipTo(parameter.patrolPoints[patrolPosition]); //面朝巡逻点

        manager.transform.position = Vector2.MoveTowards(manager.transform.position, 
            parameter.patrolPoints[patrolPosition].position, parameter.patrolSpeed * Time.deltaTime);

        if (parameter.target != null)
        {
            manager.TransitionState(StateType.Chase);
        }

        if (Vector2.Distance(manager.transform.position, parameter.patrolPoints[patrolPosition].position)< .1f)
        {
            parameter.patrolSpeed = 0f;
            timer += Time.deltaTime;
        }

        if (timer >= parameter.idleTime)
        {
            timer = 0;
            parameter.patrolSpeed = 0.6f;
            patrolPosition++; //前往数组中的下一个巡逻点

        }

        if (patrolPosition >= parameter.patrolPoints.Length)
        {
            patrolPosition = 0; //超出数组范围则设为0，循环至第一个点
        }
    }
    public void OnExit()
    {
        patrolPosition++; //前往数组中的下一个巡逻点

        if(patrolPosition >= parameter.patrolPoints.Length)
        {
            patrolPosition = 0; //超出数组范围则设为0，循环至第一个点
        }
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
        parameter.animator.Play("Walk");
    }
    public void OnUpdate()
    {
        manager.FlipTo(parameter.target);
        if (parameter.target)
        {
            manager.transform.position = Vector2.MoveTowards(manager.transform.position,
                parameter.target.position, parameter.chaseSpeed * Time.deltaTime);
            //追踪目标
        }
        if (parameter.target == null)
        {
            manager.TransitionState(StateType.Search);
        }
        if(Physics2D.OverlapCircle(parameter.attackPoint.position, parameter.attackArea, parameter.targetLayer))
        {
            manager.TransitionState(StateType.Attack);
        }
        //攻击判定范围与玩家重合时切换至攻击状态
    }
    public void OnExit()
    {

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
        parameter.animator.Play("Walk");
    }
    public void OnUpdate(){
        if (manager.transform.localScale.x == 1)
        {
            manager.transform.position += manager.transform.right * Time.deltaTime * parameter.searchSpeed;
        }
        else
        {
            manager.transform.position -= manager.transform.right * Time.deltaTime * parameter.searchSpeed;
        }

        if (parameter.target != null)
        {
            manager.TransitionState(StateType.Chase);
        }
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
    [SerializeField] private HealthController healthController = GameObject.Find("Mainchar").GetComponent<HealthController>();

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
        healthController.currentPlayerHealth -= manager.parameter.attackDamage;
        healthController.TakeDamage();  
        manager.TransitionState(StateType.Idle);
    }
    public void OnExit()
    {

    }
}
