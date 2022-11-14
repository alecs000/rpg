  using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Изменять оружие на нужное в этой переменной
    public IWeapon weapon;
    [SerializeField] private float speed;
    [SerializeField] private JoystickForMovment joystickForMovment;
    private Dictionary<Type, IPlayerBehaviour> behaviorsMap;
    private IPlayerBehaviour currentBehaviour;
    private Animator playerBodyAnimator;
    private Rigidbody2D rb;
    private void InitBehaviors()
    {
        behaviorsMap = new Dictionary<Type, IPlayerBehaviour>();
        behaviorsMap[typeof(IdlePlayerBehaviour)] = new IdlePlayerBehaviour(rb);
        behaviorsMap[typeof(RunningPlayerBehaviour)] = new RunningPlayerBehaviour(rb, speed, playerBodyAnimator, joystickForMovment, this);
        behaviorsMap[typeof(AttackPlayerBehaviour)] = new AttackPlayerBehaviour(weapon);
        behaviorsMap[typeof(DiePlayerBehavior)] = new DiePlayerBehavior(playerBodyAnimator);

    }
    private void Start()
    {
        playerBodyAnimator = GetComponent<Animator>();
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
    private void FixedUpdate()
    {
        if (currentBehaviour != null)
            currentBehaviour.FixedUpdate();
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
    public void SetBehaviourDie()
    {
        var behavior = GetBehaviour<DiePlayerBehavior>();
        if (currentBehaviour == behavior)
            return;
        SetBehaviour(behavior);
    }
}
