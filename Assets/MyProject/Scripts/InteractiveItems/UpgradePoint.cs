using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePoint : MonoBehaviour
{
    [SerializeField] AbilityPoints upgradePoint;
    [SerializeField] GameObject glow;
    public void Use(GameObject sender)
    {
        upgradePoint.Add(1);
        glow.SetActive(true);
        sender.SetActive(false);
    }
}
