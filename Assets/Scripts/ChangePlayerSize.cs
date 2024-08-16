using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerSize : MonoBehaviour
{
    private float _speed = 1f;
    public void ChangeSpeed(float speed)
    {
        _speed = speed;
    }

    private void FixedUpdate()
    {
        transform.localScale = new Vector3(_speed,_speed,_speed);
    }
}
