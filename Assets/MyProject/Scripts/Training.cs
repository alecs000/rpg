using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training : MonoBehaviour
{
    [SerializeField] private GameObject _traning;
    [SerializeField] private Canvas[] _canvas;
    private void Start()
    {
        if (PlayerPrefs.GetInt("Traning") !=1)
        {
            _traning.SetActive(true);
            foreach (Canvas canvas in _canvas)
            {
                canvas.enabled = false; 
            }
            Time.timeScale = 0;
        }
    }
    public void CloseTraning()
    {
        foreach (Canvas canvas in _canvas)
        {
            canvas.enabled = true;
        }
        PlayerPrefs.SetInt("Traning", 1);
        _traning.SetActive(false);
        Time.timeScale = 1;
    }

}
