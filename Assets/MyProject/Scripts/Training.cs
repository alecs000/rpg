using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training : MonoBehaviour
{
    [SerializeField] private Animation joystickZoneAnimation;
    // Start is called before the first frame update
    void Start()
    {
        StartTraining();
    }
    void StartTraining()
    {
        joystickZoneAnimation.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
