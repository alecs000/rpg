using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private JoystickForMovment joystickForMovment;
    [SerializeField] private JoystickForAttack JoystickForAttack;
    public static bool isAttack;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void AttackEnd()
    {
        player.SetBehaviourIdle();
        isAttack = false;
    }
    void Update()
    {
        Debug.Log(isAttack);
        if (isAttack)
            return;
        if (joystickForMovment.vectorDirection!= Vector2.zero)
        {
            player.SetBehaviourRunning();
            return;
        }
        Debug.Log(JoystickForAttack.vectorAttack);

        if (JoystickForAttack.vectorAttack.x>0.5||JoystickForAttack.vectorAttack.x < -0.5 || JoystickForAttack.vectorAttack.y > 0.5 || JoystickForAttack.vectorAttack.y < -0.5)
        {
            Debug.Log("Attack");
            player.SetBehaviourAttackSword();
            return;
        }
    }
}
