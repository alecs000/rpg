using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateRune : MonoBehaviour
{
    [SerializeField] private GameObject glow;
    [SerializeField] private GameObject notification;
    [SerializeField] private Text notificationText;
    [SerializeField] private BoxCollider2D boxCollider2D;
    private Animation anim;
    private void Start()
    {
        anim = notification.GetComponent<Animation>();
    }
    public void Activate(GameObject sender)
    {
        boxCollider2D.enabled = false;
        sender.SetActive(false);
        glow.SetActive(true);
        notificationText.text = "+ 1 magic eye";
        notificationText.color = "7ADBDD".ToColor();
        notification.SetActive(true);
        StartCoroutine(CloseNotification());
    }
    IEnumerator CloseNotification()
    {
        yield return new WaitForSeconds(3);
        anim.Play();
        yield return new WaitForSeconds(1);
        notification.SetActive(false);
    }
}
