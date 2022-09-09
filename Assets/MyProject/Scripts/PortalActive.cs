using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalActive : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private GameObject[] runes;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (var rune in runes)
        {
            rune.SetActive(true);
        }
        _particleSystem.Play();
    }

}
