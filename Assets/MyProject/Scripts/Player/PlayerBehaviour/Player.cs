  using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Изменять оружие на нужное в этой переменной
    public IWeapon Weapon;
    [SerializeField] private float _speed;
    [SerializeField] private JoystickForMovment _joystickForMovment;
    private Dictionary<Type, IPlayerBehaviour> _behaviorsMap;
    private IPlayerBehaviour _currentBehaviour;
    private Animator _playerBodyAnimator;
    private Rigidbody2D _playerRigidbody;
    private void InitBehaviors()
    {
        _behaviorsMap = new Dictionary<Type, IPlayerBehaviour>();
        _behaviorsMap[typeof(IdlePlayerBehaviour)] = new IdlePlayerBehaviour(_playerRigidbody, _playerBodyAnimator);
        _behaviorsMap[typeof(RunningPlayerBehaviour)] = new RunningPlayerBehaviour(_playerRigidbody, _speed, _playerBodyAnimator, _joystickForMovment, this);
        _behaviorsMap[typeof(AttackPlayerBehaviour)] = new AttackPlayerBehaviour(Weapon);
        _behaviorsMap[typeof(DiePlayerBehavior)] = new DiePlayerBehavior(_playerBodyAnimator);

    }
    private void Start()
    {
        _playerBodyAnimator = GetComponent<Animator>();
        _playerRigidbody = GetComponent<Rigidbody2D>();
        InitBehaviors();
        SetBehaviourByDefoult();
    }
    private void SetBehaviour(IPlayerBehaviour newBehavior)
    {
        if (_currentBehaviour != null)
            _currentBehaviour.Exit();
        _currentBehaviour = newBehavior;
        _currentBehaviour.Enter();
    }
    private void SetBehaviourByDefoult()
    {
        SetBehaviourIdle();
    }
    private IPlayerBehaviour GetBehaviour<T>() where T : IPlayerBehaviour
    {
       var type = typeof(T);
        return  this._behaviorsMap[type];
    }
    private void Update()
    {
        if (_currentBehaviour != null)
            _currentBehaviour.Update();
    }
    private void FixedUpdate()
    {
        if (_currentBehaviour != null)
            _currentBehaviour.FixedUpdate();
    }
    public void SetBehaviourIdle()
    { 
        var behavior = GetBehaviour<IdlePlayerBehaviour>();
        if (_currentBehaviour == behavior)
            return;
        SetBehaviour(behavior);
    }
    public void SetBehaviourRunning()
    {
        var behavior = GetBehaviour<RunningPlayerBehaviour>();
        if (_currentBehaviour == behavior)
            return;
        SetBehaviour(behavior);
    }
    public void SetBehaviourAttack()
    {
        var behavior = GetBehaviour<AttackPlayerBehaviour>();
        if (_currentBehaviour == behavior)
            return;
        SetBehaviour(behavior);
    }
    public void SetBehaviourDie()
    {
        var behavior = GetBehaviour<DiePlayerBehavior>();
        if (_currentBehaviour == behavior)
            return;
        SetBehaviour(behavior);
    }
}
