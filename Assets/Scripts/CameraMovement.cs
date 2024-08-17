using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [Header("Player variables")]
    [SerializeField] Transform player;
    [SerializeField] ChangePlayerSize scriptSize;
    [SerializeField] PlayerInput playerInput;

    [Header("Boundaries")]
    [SerializeField] Vector3 minValue;
    [SerializeField] Vector3 maxValue;

    [Header("Smooth factor")]
    [Range(3f, 10f)]
    [SerializeField] float smoothFactor;

    [Header("Animation curve")]
    [SerializeField] AnimationCurve curve;

    private float _curveTime = 1.5f;
    private bool _isAnimationFinished = false;

    private void Start()
    {
        playerInput.enabled = false;
        scriptSize.enabled = false;
        StartCoroutine(StartAnimation());
    }

    private IEnumerator StartAnimation()
    {
        float elapsedTime = 0;

        yield return new WaitForSeconds(0.8f);

        while (Camera.main.orthographicSize > 4)
        {
            elapsedTime += Time.deltaTime;
            float percentageCompleted = elapsedTime / _curveTime;
            Camera.main.orthographicSize = Mathf.Lerp(8, 4, curve.Evaluate(percentageCompleted));
            Vector3 smoothedPosition = Vector3.Lerp(new Vector3(0,0,-10), 
                new Vector3(player.position.x, player.position.y, -10), 
                curve.Evaluate(percentageCompleted));
            transform.position = smoothedPosition;

            yield return new WaitForFixedUpdate();
        }
        Camera.main.orthographicSize = 4;
        _isAnimationFinished = true;

        scriptSize.enabled = true;
        playerInput.enabled = true;
    }

    void FixedUpdate()
    {
        if (_isAnimationFinished)
        {
            Vector3 targetPosition = player.position;

            Vector3 boundPosition = new Vector3(Mathf.Clamp(targetPosition.x, minValue.x, maxValue.x),
                Mathf.Clamp(targetPosition.y, minValue.y, maxValue.y),
                Mathf.Clamp(targetPosition.z, minValue.z, maxValue.z));

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, boundPosition, smoothFactor*Time.fixedDeltaTime);
            transform.position = smoothedPosition;
        }
        
    }
}
