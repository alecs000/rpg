using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalActive : MonoBehaviour
{
    public int MoneyOnLevel;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private GameObject _runes;
    [SerializeField] private GameObject _menu;
    [SerializeField] private AudioSource _portalAudioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("Scene", SceneManager.GetActiveScene().buildIndex + 1);
            _runes.SetActive(true);
            _particleSystem.Play();
            PlayerPrefs.SetInt("MoneyInLastLevel", 0);
            MoneyOnLevel = Money.instance.GetMoneyOnLevel();
            collision.gameObject.SetActive(false);
            _portalAudioSource.Play();
            StartCoroutine(ShowMenu());
        }
    }
    IEnumerator ShowMenu()
    {
        yield return new WaitForSeconds(0.4f);
        _menu.SetActive(true);
    }
}
