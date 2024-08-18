using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public static PlayMusic Instance { get; set; }

    private AudioSource _source;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        _source = GetComponent<AudioSource>();
    }
    public void Play()
    {
        _source.Play();
    }

    public void Stop()
    {
        _source.Stop();
    }

}
