using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 3f;

    private Rigidbody2D _rb;
    private Vector2 _velocity;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnMove(InputValue value)
    {
        _velocity = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {

        _rb.MovePosition(_rb.position + _velocity * speed * Time.fixedDeltaTime);
    }
}
