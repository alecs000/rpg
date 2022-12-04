using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenuManager : MonoBehaviour
{
    [SerializeField] Animation endMenuAnimation;
    public void ClickShop()
    {
        endMenuAnimation.Play();
        StartCoroutine(SwitchScene(0));
    }
    public void ClickNextLevel()
    {
        endMenuAnimation.Play();
        StartCoroutine(SwitchScene(PlayerPrefs.GetInt("Scene")));
    }
    public void ClickRestart()
    {
        endMenuAnimation.Play();
        StartCoroutine(SwitchScene(SceneManager.GetActiveScene().buildIndex));
    }
    IEnumerator SwitchScene(int sceneIndex)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneIndex);
    }
}
