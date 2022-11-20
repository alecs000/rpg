using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PortalActive : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private GameObject _runes;
    [SerializeField] private GameObject _menu;
    [SerializeField] private Text moneyText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _runes.SetActive(true);
        _particleSystem.Play();
        moneyText.text =$"+{Money.instance.GetMoneyOnLavel().ToString()} coins";
        collision.gameObject.SetActive(false);
        StartCoroutine(ShowMenu());
    }
    IEnumerator ShowMenu()
    {
        yield return new WaitForSeconds(0.4f);
        _menu.SetActive(true);
    }
}
