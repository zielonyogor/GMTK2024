using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 3f;

    private Rigidbody2D _rb;
    private Vector2 _velocity;
    private Animator _animator;

    Vector3 _rotationVector = Vector3.zero;

    private void Awake()
    {
        _rotationVector.z = transform.eulerAngles.z;
        Debug.Log(transform.rotation.z);
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void OnMove(InputValue value)
    {
        _velocity = value.Get<Vector2>();
        if(_velocity.x < 0)
        {
            _rotationVector.z = 90;
            _animator.SetBool("isWalking", true);
        }
        if (_velocity.x > 0)
        {
            _rotationVector.z = -90;
            _animator.SetBool("isWalking", true);
        }
        if (_velocity.y < 0)
        {
            _rotationVector.z = 180;
            _animator.SetBool("isWalking", true);
        }
        if (_velocity.y > 0)
        {
            _rotationVector.z = 0;
            _animator.SetBool("isWalking", true);
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(_rotationVector);
        _rb.MovePosition(_rb.position + _velocity * speed * Time.fixedDeltaTime);
        if(_velocity == Vector2.zero)
        {
            _animator.SetBool("isWalking", false);
        }
    }
}
