using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerLightBehavior : MonoBehaviour
{
    [SerializeField] private Transform _playerLight;
    [SerializeField] private JoystickForAttack _playerJoystickForAttack;
    [SerializeField] private JoystickForMovment _playerJoystickMovment;
    private void Update()
    {
        if(_playerJoystickForAttack.VectorAttack!= Vector2.zero)
        {
            _playerLight.transform.rotation = Quaternion.Euler(0, 0, _playerJoystickForAttack.GetAngle()-90);
        }
        else if (_playerJoystickMovment.VectorDirection!=Vector2.zero)
        {
            _playerLight.transform.rotation = Quaternion.Euler(0, 0, _playerJoystickMovment.GetAngle()-90);
        }
    }
}
