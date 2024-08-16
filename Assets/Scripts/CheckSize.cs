using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSize : MonoBehaviour
{
    [SerializeField] LayerMask wallMask;
    [SerializeField] float offset = 0.03f;

    private float _playerWidth, _playerHeight;
    
    void FixedUpdate()
    {
        _playerWidth = transform.localScale.x;
        _playerHeight = transform.localScale.y;

        Debug.DrawRay(transform.position, new Vector2(0, _playerHeight/2 - offset), Color.green);
        Debug.DrawRay(transform.position, new Vector2(0, -(_playerHeight / 2 - offset)), Color.green);
        Debug.DrawRay(transform.position, new Vector2(_playerWidth / 2 - offset, 0), Color.green);
        Debug.DrawRay(transform.position, new Vector2( -(_playerWidth / 2 - offset), 0), Color.green);

        RaycastHit2D hitUp = Physics2D.Raycast(transform.position, Vector2.up, _playerHeight / 2 - offset, wallMask);
        RaycastHit2D hitDown = Physics2D.Raycast(transform.position, Vector2.down, _playerHeight / 2 - offset, wallMask);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, _playerWidth / 2 - offset, wallMask);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, _playerWidth / 2 - offset, wallMask);

        if (hitUp.collider != null || hitDown.collider != null
            || hitLeft.collider != null || hitRight.collider != null)
        {
            GameManager.Instance.GameOver(Constants.GameOverState.PlayerTooBig);
        }
    }
}
