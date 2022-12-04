using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateRune : MonoBehaviour
{
    [SerializeField] private GameObject _glow;
    [SerializeField] private GameObject _notification;
    [SerializeField] private BoxCollider2D _boxCollider2D;
    [SerializeField] private AudioSource _runeAudioSource;

    private Animation _notificationAnimator;
    private void Start()
    {
        _notificationAnimator = _notification.GetComponent<Animation>();
    }
    public void Activate(GameObject sender)
    {
        _boxCollider2D.enabled = false;
        sender.SetActive(false);
        _glow.SetActive(true);
        _notification.SetActive(true);
        _runeAudioSource.Play();
        StartCoroutine(CloseNotification());
    }
    IEnumerator CloseNotification()
    {
        yield return new WaitForSeconds(3);
        _notificationAnimator.Play();
        yield return new WaitForSeconds(1);
        _notification.SetActive(false);
    }
}
