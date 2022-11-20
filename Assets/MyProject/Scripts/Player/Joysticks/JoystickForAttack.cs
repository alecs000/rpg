using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickForAttack : JoysticDefault
{
    public Vector2 VectorAttack => _inputPosition.normalized;
    public float GetAngle()
    {
        if (VectorAttack.x==0)
        {
            if (VectorAttack.y > 0)
                return 90;
            else
                return 270;
        }
        double radians = Math.Atan(VectorAttack.y / VectorAttack.x);
        float angle = (float)Math.Abs(radians * (180 / Math.PI));
        if (VectorAttack.x < 0 && VectorAttack.y < 0)
        {
            angle += 180;
        }
        else if (VectorAttack.x < 0)
        {
            angle = 180 - angle;
        }
        else if (VectorAttack.y < 0)
        {
            angle = 360 - angle;
        }
        return angle;
    }
}
