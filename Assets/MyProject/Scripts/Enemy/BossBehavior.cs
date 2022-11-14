using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    [SerializeField] private GameObject endMenu;
    public void EndDie()
    {
        endMenu.SetActive(true);
    }
}
