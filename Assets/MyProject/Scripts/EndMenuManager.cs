using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenuManager : MonoBehaviour
{
    public void ClickShop()
    {
        SceneManager.LoadScene(7);
    }
    public void ClickNextLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Scene"));
    }
    public void ClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
