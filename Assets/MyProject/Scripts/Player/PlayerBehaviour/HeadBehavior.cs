using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBehavior : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _headSpriteRenderer;
    public void SwitchColor(Color color)
    {
        _headSpriteRenderer.color = color;
    }
}
