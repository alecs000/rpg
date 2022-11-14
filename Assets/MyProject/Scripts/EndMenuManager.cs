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
        SceneManager.LoadScene(0);
    }
    public void ClickNextLevel()
    {
        anim.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void ClickRestart()
    {
        anim.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
