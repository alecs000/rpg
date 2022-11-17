using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenuManager : MonoBehaviour
{
    [SerializeField] Animation anim;
    public void ClickShop()
    {
        anim.Play();
        StartCoroutine(SwitchScene(0));
    }
    public void ClickNextLevel()
    {
        anim.Play();
        StartCoroutine(SwitchScene(SceneManager.GetActiveScene().buildIndex+1));
    }
    public void ClickRestart()
    {
        anim.Play();
        StartCoroutine(SwitchScene(SceneManager.GetActiveScene().buildIndex));
    }
    IEnumerator SwitchScene(int sceneIndex)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneIndex);

    }
}
