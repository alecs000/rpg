using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private JoystickForMovment joystickForMovment;
    [SerializeField] private JoystickForAttack JoystickForAttack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (joystickForMovment.vectorDirection!= Vector2.zero)
        {
            player.SetBehaviourRunning();
            return;
        }
        if (JoystickForAttack.vectorAttack != Vector2.zero)
        {
            player.SetBehaviourAttackSword();
            return;
        }
    }
}
