using UnityEngine;
using UnityEngine.SceneManagement;

public class BossBehavior : MonoBehaviour
{
    public int MoneyOnLevel;

    [SerializeField] private GameObject _endMenu;
    [SerializeField] private GameObject _player;
    [SerializeField] private AudioSource _musicAudioSource;

    public void EndDie()
    {
        PlayerPrefs.SetInt("Scene", SceneManager.GetActiveScene().buildIndex + 1);
        _musicAudioSource.Stop();
        PlayerPrefs.SetInt("MoneyInLastLevel", 0);
        MoneyOnLevel = Money.instance.GetMoneyOnLevel();
        _player.SetActive(false);

        _endMenu.SetActive(true);

    }
}
