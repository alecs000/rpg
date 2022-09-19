using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdlePlayerBehaviour : IPlayerBehaviour
{
    public void Enter()
    {
        Debug.Log("Enter Idle State");
    }

    public void Exit()
    {
        Debug.Log("Exit Idle State");

    }

    void IPlayerBehaviour.Update()
    {
        Debug.Log("Update Idle State");
    }
}
