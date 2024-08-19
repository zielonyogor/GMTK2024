using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    private TextMeshProUGUI _text;

    void Start()
    {
        _background = GetComponent<Image>();
        _index = GameManager.Instance.cutsceneBackground;
        _text = transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        StartCoroutine(ShowGameScreen());
    }

    private IEnumerator ShowGameScreen()
    {
        _background.sprite = endings[_index];
        PlayMusic.Instance.Stop();
        if (_index <= 1)
        {
            if (_index == 0)
            {
                _text.text = "You grew too much";
            }
            else
            {
                _text.text = "You shrank into size of atoms";
            }
            audioSource.Play();
        }
        else
        {
            _text.text = "You can finally sleep in peace";
            audioSource.clip = gameWonClip;
            audioSource.Play();
        }
        yield return new WaitForSeconds(3f);
        PlayMusic.Instance.Play();
        SceneManager.LoadScene("MainMenu");
    }
}
