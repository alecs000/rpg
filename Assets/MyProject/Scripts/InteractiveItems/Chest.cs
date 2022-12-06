using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private ChestBehaviour _chestBehaviour;
    [SerializeField] private int _index;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _chestBehaviour.Index = _index;
        }
    }
}
