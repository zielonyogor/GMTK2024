using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBounds : MonoBehaviour
{
    private Bounds _bounds;
    private void Awake()
    {
        _bounds = GetComponent<BoxCollider2D>().bounds;
        Global.worldBounds = _bounds;
    }
}
