using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    [SerializeField] private GameObject _endMenu;
    public void EndDie()
    {
        _endMenu.SetActive(true);
    }
}
