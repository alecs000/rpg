  using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public IWeapon weapon; // Изменять оружие на нужное в этой переменной
    [SerializeField] private float speed;
    [SerializeField] private JoystickForMovment joystickForMovment;
    private Dictionary<Type, IPlayerBehaviour> behaviorsMap;
    private IPlayerBehaviour currentBehaviour;
    private Animator animatorBody;
    private Rigidbody2D rb;
    private void InitBehaviors()
    {
        behaviorsMap = new Dictionary<Type, IPlayerBehaviour>();
        behaviorsMap[typeof(IdlePlayerBehaviour)] = new IdlePlayerBehaviour();
        behaviorsMap[typeof(RunningPlayerBehaviour)] = new RunningPlayerBehaviour(rb, speed, animatorBody, joystickForMovment, this);
        behaviorsMap[typeof(AttackPlayerBehaviour)] = new AttackPlayerBehaviour(weapon);

    }
    private void Start()
    {
        animatorBody = GetComponent<Animator>();
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
    public void SetBehaviourAttack()
    {
        var behavior = GetBehaviour<AttackPlayerBehaviour>();
        if (currentBehaviour == behavior)
            return;
        SetBehaviour(behavior);
    }
}
