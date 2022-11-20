using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePoint : MonoBehaviour
{
    [SerializeField] AbilityPoints _upgradePoint;
    [SerializeField] GameObject _glow;
    public void Use(GameObject sender)
    {
        _upgradePoint.Add(1);
        _glow.SetActive(true);
        sender.SetActive(false);
    }
}
