using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerSize : MonoBehaviour
{
    private float _speed = 0f;
    private float _curveTime = 2f;

    [Header("Constant speed of changing size")]
    [Range(0f, 0.3f)]
    [SerializeField] float _minSpeed = 0.05f;

    [Header("Initial size boost")]
    [Range(-10f, 10f)]
    [SerializeField] float initialSpeed = 1.5f;

    [Header("Speed changing curve")]
    [SerializeField] AnimationCurve speedCurve;

    private void Start()
    {
        StartCoroutine(ChangeSpeedSmooth(initialSpeed));
    }

    private void FixedUpdate()
    {
        transform.localScale = new Vector2(transform.localScale.x + _speed * Time.deltaTime, 
            transform.localScale.y + _speed * Time.deltaTime);

        if (transform.localScale.x < 0.4)
        {
            GameManager.Instance.GameOver(Constants.GameEndState.PlayerTooSmall);
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
        float elapsedTime = 0;
        _speed = initialSpeed;
        while (Mathf.Abs(_speed) > _minSpeed)
        {
            elapsedTime += Time.deltaTime;
            float percentageCompleted = elapsedTime / _curveTime;
            _speed = Mathf.Lerp(initialSpeed, _minSpeed * direction, speedCurve.Evaluate(percentageCompleted));
            yield return new WaitForFixedUpdate();
        }
        _speed = _minSpeed * direction;
    }
}
