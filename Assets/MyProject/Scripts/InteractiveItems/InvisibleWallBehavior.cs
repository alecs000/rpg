using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvisibleWallBehavior : MonoBehaviour
{
    [SerializeField] private GameObject _notification;
    [SerializeField] private Text _chestNotification;
    private bool _keyReceived;
    private Animator _notificationAnim;
    private void Start()
    {
        _notificationAnim = _notification.GetComponent<Animator>();   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_keyReceived)
        {
            _notification.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!_keyReceived)
        {
            StartCoroutine(CloseNotification());
        }
    }
    IEnumerator CloseNotification()
    {
        _notificationAnim.SetBool("Disappear", true);
        yield return new WaitForSeconds(1);
        _notification.SetActive(false);
    }
    public void FindKey()
    {
        _keyReceived = true;
        _chestNotification.text += " +1 Key";
    }
}
