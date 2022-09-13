using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private Dictionary<Type, IPlayerBehaviour> behaviorsMap;
    private IPlayerBehaviour currentBehaviour;
    private Animator animator;
    private Rigidbody2D rb;
    private void InitBehaviors()
    {
        behaviorsMap = new Dictionary<Type, IPlayerBehaviour>();
        behaviorsMap[typeof(IdlePlayerBehaviour)] = new IdlePlayerBehaviour();
        behaviorsMap[typeof(RunningPlayerBehaviour)] = new RunningPlayerBehaviour(rb,speed, animator);

    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        InitBehaviors();
        SetBehaviourByDefoult();
    }
    private void SetBehaviour(IPlayerBehaviour newBehavior)
    {
        if (currentBehaviour != null)
            currentBehaviour.Exit();
        currentBehaviour = newBehavior;
        currentBehaviour.Enter();
    }
    private void SetBehaviourByDefoult()
    {
        SetBehaviourIdle();
    }
    private IPlayerBehaviour GetBehaviour<T>() where T : IPlayerBehaviour
    {
       var type = typeof(T);
        return  this.behaviorsMap[type];
    }
    private void Update()
    {
        if (currentBehaviour != null)
            currentBehaviour.Update();
    }
    public void SetBehaviourIdle()
    { 
        var behavior = GetBehaviour<IdlePlayerBehaviour>();
        if (currentBehaviour == behavior)
            return;
        SetBehaviour(behavior);
    }
    public void SetBehaviourRunning()
    {
        var behavior = GetBehaviour<RunningPlayerBehaviour>();
        if (currentBehaviour == behavior)
            return;
        SetBehaviour(behavior);
    }
}
