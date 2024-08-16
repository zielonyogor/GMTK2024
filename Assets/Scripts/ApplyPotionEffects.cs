using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyPotionEffects : MonoBehaviour
{
    [Header("Effect of a potion")]
    [Tooltip("How fast player will increase/decrease in size")]
    [SerializeField] float speed = 1f;

    private BoxCollider2D _collider;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(_collider); //disable collider first to make sure on trigger doesn't get triggered more than once
        if (collision.transform.CompareTag("Player"))
        {
            ChangePlayerSize script = collision.GetComponent<ChangePlayerSize>();
            if (script != null)
            {
                script.ChangeSpeed(speed);
            }
        }
        Destroy(this.gameObject);
    }
}
