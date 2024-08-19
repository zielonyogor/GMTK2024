using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialItem : MonoBehaviour
{
    [Header("Item sound effect")]
    [SerializeField] AudioSource audioSource;

    [Header("Particles")]
    [SerializeField] GameObject particlesObject;
    private ParticleSystem _particles;

    private BoxCollider2D _collider;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(_collider);

        audioSource.Play();
        GameObject spawnedParticles = Instantiate(particlesObject, this.transform.position, Quaternion.identity);
        _particles = spawnedParticles.GetComponent<ParticleSystem>();
        _particles.Play();

        GameManager.Instance.CountSpecialItem();

        Destroy(transform.parent.gameObject);
    }
}
