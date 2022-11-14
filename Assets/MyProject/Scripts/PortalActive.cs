using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalActive : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private GameObject runes;
    [SerializeField] private GameObject menu;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        runes.SetActive(true);
        _particleSystem.Play();
        StartCoroutine(ShowMenu());
    }
    IEnumerator ShowMenu()
    {
        yield return new WaitForSeconds(0.4f);
        menu.SetActive(true );
    }
}
