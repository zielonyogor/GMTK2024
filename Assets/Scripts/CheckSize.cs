using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSize : MonoBehaviour
{
    [SerializeField] LayerMask wallMask;
    [SerializeField] float offset = 0.03f;

    private float _playerWidth, _playerHeight;

    private BoxCollider2D _collider;
    private float _colliderOffset = 0;

    private void Start()
    {
         _collider = GetComponent<BoxCollider2D>();
        _colliderOffset = _collider.offset.y;
    }

    void FixedUpdate()
    {
        Bounds bounds = _collider.bounds;

        //if (transform.rotation.eulerAngles.z == 90 || transform.rotation.eulerAngles.z == 270)
        //{
        //    _playerWidth = bounds.extents.y;
        //    _playerHeight = bounds.extents.x;
        //}
        //else
        //{
        //    _playerWidth = bounds.extents.x;
        //    _playerHeight = bounds.extents.y;
        //}

        _playerWidth = bounds.extents.x;
        _playerHeight = bounds.extents.y;

        Vector2 fixedPosition = (transform.position
            + transform.rotation * new Vector3(0, transform.localScale.y * _colliderOffset, 0));

        Debug.DrawRay(fixedPosition,
            new Vector2(0, _playerHeight - offset), Color.red);
        Debug.DrawRay(fixedPosition,
            new Vector2(0, -(_playerHeight - offset)), Color.green);
        Debug.DrawRay(fixedPosition,
            new Vector2(_playerWidth - offset, 0), Color.blue);
        Debug.DrawRay(fixedPosition,
            new Vector2(-(_playerWidth - offset), 0), Color.magenta);

        RaycastHit2D hitUp = Physics2D.Raycast(fixedPosition,
            Vector2.up, _playerHeight - offset, wallMask);
        RaycastHit2D hitDown = Physics2D.Raycast(fixedPosition,
            Vector2.down, _playerHeight - offset, wallMask);
        RaycastHit2D hitLeft = Physics2D.Raycast(fixedPosition,
            Vector2.left, _playerWidth - offset, wallMask);
        RaycastHit2D hitRight = Physics2D.Raycast(fixedPosition,
            Vector2.right, _playerWidth - offset, wallMask);

        if (hitUp.collider != null || hitDown.collider != null
            || hitLeft.collider != null || hitRight.collider != null)
        {
            GameManager.Instance.GameOver(Constants.GameOverState.PlayerTooBig);
        }
    }
}
