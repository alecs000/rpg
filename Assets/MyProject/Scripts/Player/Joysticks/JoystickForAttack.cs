using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickForAttack : JoysticDefault
{
    public Vector2 vectorAttack => inputPosition.normalized;
    public float GetAngle()
    {
        float radians = (float)Math.Atan(vectorAttack.y / vectorAttack.x);
        float angle = (float)Math.Abs(radians * (180 / Math.PI));
        if (vectorAttack.x < 0 && vectorAttack.y < 0)
        {
            angle += 180;
        }
        else if (vectorAttack.x < 0)
        {
            angle = 180 - angle;
        }
        else if (vectorAttack.y < 0)
        {
            angle = 360 - angle;
        }
        return angle;
    }
}
