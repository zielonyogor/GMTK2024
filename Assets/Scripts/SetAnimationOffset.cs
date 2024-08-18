using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimationOffset : MonoBehaviour
{
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
        float offset = Random.Range(0f, 1f);

        _animator.Play("ItemIdle", 0, offset);
    }
}
