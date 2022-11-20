using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform _playerTransform;
    [SerializeField] float _movingSpeed;
    private void FixedUpdate()
    {
        if (_playerTransform)
        {
            Vector3 target = new Vector3(_playerTransform.position.x, _playerTransform.position.y, -10f);
            Vector3 pos = Vector3.Lerp(this.transform.position, target, _movingSpeed * Time.deltaTime);
            transform.position = pos;
        }
    }
}
