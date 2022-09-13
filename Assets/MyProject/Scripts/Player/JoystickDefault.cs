using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class JoysticDefault : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private Image joystick;
    [SerializeField] private Image joystickZone;
    [SerializeField] private Image joystickBackground;
    private bool isJoystickActive =false;
    protected static Vector2 inputPosition;

    // Start is called before the first frame update
    private void SwitchJoystick()
    {
        if (isJoystickActive)
        {
            joystickBackground.enabled = false;
            joystick.enabled = false;
            isJoystickActive = false;
            return;
        }
        else
        {
            joystickBackground.enabled = true;
            joystick.enabled = true;
            isJoystickActive = true;    
            return;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        SwitchJoystick();
        Vector2 backgroundAreaPosition;
        Debug.Log("w");
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickZone.rectTransform, eventData.position, null, out backgroundAreaPosition))
        {
            joystickBackground.rectTransform.anchoredPosition = new Vector2(backgroundAreaPosition.x, backgroundAreaPosition.y); ;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 joystickPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBackground.rectTransform, eventData.position, null, out joystickPosition))
        {
            joystickPosition.x = joystickPosition.x * 2 / joystickBackground.rectTransform.sizeDelta.x;
            joystickPosition.y = joystickPosition.y * 2 / joystickBackground.rectTransform.sizeDelta.y;
            inputPosition = new Vector2(joystickPosition.x, joystickPosition.y);
            if (inputPosition.magnitude > 1)
                inputPosition = inputPosition.normalized;
            joystick.rectTransform.anchoredPosition = new Vector2(inputPosition.x *( joystickBackground.rectTransform.sizeDelta.x / 2), inputPosition.y * (joystickBackground.rectTransform.sizeDelta.y / 2));
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        joystick.rectTransform.anchoredPosition = Vector2.zero;
        inputPosition = Vector2.zero;
        SwitchJoystick();
    }

}
