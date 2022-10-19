using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thron : MonoBehaviour
{
    [SerializeField] DarkCharacter character;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().GetDamage(character.damage);
        }
    }
}
