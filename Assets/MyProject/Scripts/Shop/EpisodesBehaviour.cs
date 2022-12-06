using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EpisodesBehaviour : MonoBehaviour
{
    [SerializeField] private Button[] _episodesButtons;
    private void OnEnable()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("Scene"); i++)
        {
            _episodesButtons[i].interactable = true;
        }
    }
    public void StartEpisode(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void StartNextEpisodel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Scene"));
    }
}
