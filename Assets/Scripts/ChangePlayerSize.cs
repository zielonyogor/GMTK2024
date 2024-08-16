using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerSize : MonoBehaviour
{
    private float _speed = 0f;
    private float _minSpeed = 0.02f;

    private void FixedUpdate()
    {
        transform.localScale = new Vector2(transform.localScale.x + _speed * Time.deltaTime, 
            transform.localScale.y + _speed * Time.deltaTime);

        if (transform.localScale.x < 0.5)
        {
            GameManager.Instance.GameOver(Constants.GameOverState.PlayerTooSmall);
        }
    }
    public void ChangeSpeed(float speed)
    {
        StopAllCoroutines();
        StartCoroutine(ChangeSpeedSmooth(speed));
    }

    private IEnumerator ChangeSpeedSmooth(float initialSpeed)
    {
        int direction = initialSpeed < 0 ? -1 : 1;
        _speed = initialSpeed;
        while (Mathf.Abs(_speed) > _minSpeed)
        {
            _speed = Mathf.Lerp(_speed, _minSpeed * direction, Time.fixedDeltaTime * 1.2f);
            yield return new WaitForFixedUpdate();
        }
        _speed = _minSpeed * direction;
    }
}
