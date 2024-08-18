using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowCutscene : MonoBehaviour
{
    [SerializeField] List<Sprite> endings;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip gameWonClip;

    private Image _background;
    private int _index;

    void Start()
    {
        _background = GetComponent<Image>();
        _index = GameManager.Instance.cutsceneBackground;
        StartCoroutine(ShowGameScreen());
    }

    private IEnumerator ShowGameScreen()
    {
        _background.sprite = endings[_index];
        PlayMusic.Instance.Stop();
        if (_index <= 1)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.clip = gameWonClip;
            audioSource.Play();
        }
        yield return new WaitForSeconds(3f);
        PlayMusic.Instance.Play();
        SceneManager.LoadScene("MainMenu");
    }
}
