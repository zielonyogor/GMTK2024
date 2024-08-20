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

    [Header("Smooth factor")]
    [Range(3f, 10f)]
    [SerializeField] float smoothFactor;

    [Header("Animation curve")]
    [SerializeField] AnimationCurve curve;

    private float _curveTime = 1.5f;
    private bool _isAnimationFinished = false;

    private float _startSize; 

    private void Start()
    {
        _startSize = Camera.main.orthographicSize;

        playerInput.enabled = false;
        scriptSize.enabled = false;
        StartCoroutine(StartAnimation());
    }

    private IEnumerator StartAnimation()
    {
        float elapsedTime = 0;

        yield return new WaitForSeconds(1.8f);

        while (Camera.main.orthographicSize > 4)
        {
            elapsedTime += Time.deltaTime;
            float percentageCompleted = elapsedTime / _curveTime;
            Camera.main.orthographicSize = Mathf.Lerp(_startSize, 4, curve.Evaluate(percentageCompleted));
            transform.position = Vector3.Lerp(transform.position, LimitPosition(player.position), smoothFactor * Time.fixedDeltaTime);

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
            transform.position = Vector3.Lerp(transform.position, LimitPosition(player.position), smoothFactor * Time.fixedDeltaTime);
        }
    }

    private Vector3 LimitPosition(Vector3 position)
    {
        float height = Camera.main.orthographicSize;
        float width = height * Camera.main.aspect;

        float minX = Global.worldBounds.min.x + width;
        float maxX = Global.worldBounds.extents.x - width;

        float minY = Global.worldBounds.min.y + height;
        float maxY = Global.worldBounds.extents.y - height;

        Vector3 newPosition = new Vector3(Mathf.Clamp(position.x, minX, maxX),
                Mathf.Clamp(position.y, minY, maxY),
                -10f);

        return newPosition;
    }
}
