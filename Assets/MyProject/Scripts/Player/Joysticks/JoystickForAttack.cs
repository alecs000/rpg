using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickForAttack : JoysticDefault
{
    public Vector2 VectorAttack => _inputPosition.normalized;
}
