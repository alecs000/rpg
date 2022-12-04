using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public abstract class JoysticDefault : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private Image _joystick;
    [SerializeField] private Image _joystickZone;
    [SerializeField] private Image _joystickBackground;
    private bool _isJoystickActive =false;
    protected Vector2 _inputPosition;
    // Start is called before the first frame update
    private void SwitchJoystick()
    {
        if (_isJoystickActive)
        {
            _joystickBackground.enabled = false;
            _joystick.enabled = false;
            _isJoystickActive = false;
            return;
        }
        else
        {
            _joystickBackground.enabled = true;
            _joystick.enabled = true;
            _isJoystickActive = true;    
            return;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        SwitchJoystick();
        Vector2 backgroundAreaPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickZone.rectTransform, eventData.position, null, out backgroundAreaPosition))
        {
            _joystickBackground.rectTransform.anchoredPosition = new Vector2(backgroundAreaPosition.x, backgroundAreaPosition.y); ;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 joystickPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickBackground.rectTransform, eventData.position, null, out joystickPosition))
        {
            joystickPosition.x = joystickPosition.x * 2 / _joystickBackground.rectTransform.sizeDelta.x;
            joystickPosition.y = joystickPosition.y * 2 / _joystickBackground.rectTransform.sizeDelta.y;
            _inputPosition = new Vector2(joystickPosition.x, joystickPosition.y);
            if (_inputPosition.magnitude > 1)
                _inputPosition = _inputPosition.normalized;
            _joystick.rectTransform.anchoredPosition = new Vector2(_inputPosition.x *( _joystickBackground.rectTransform.sizeDelta.x / 2), _inputPosition.y * (_joystickBackground.rectTransform.sizeDelta.y / 2));
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        _joystick.rectTransform.anchoredPosition = Vector2.zero;
        _inputPosition = Vector2.zero;
        SwitchJoystick();
    }
    public float GetAngle()
    {
        Vector2 VectorAttack = _inputPosition.normalized;
        if (VectorAttack.x == 0)
        {
            if (VectorAttack.y > 0)
                return 90;
            else
                return 270;
        }
        double radians = Math.Atan(VectorAttack.y / VectorAttack.x);
        float angle = (float)Math.Abs(radians * (180 / Math.PI));
        if (VectorAttack.x < 0 && VectorAttack.y < 0)
        {
            angle += 180;
        }
        else if (VectorAttack.x < 0)
        {
            angle = 180 - angle;
        }
        else if (VectorAttack.y < 0)
        {
            angle = 360 - angle;
        }
        return angle;
    }

}
