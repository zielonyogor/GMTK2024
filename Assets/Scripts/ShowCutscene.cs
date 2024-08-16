using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowCutscene : MonoBehaviour
{
    [SerializeField] List<Sprite> endings;

    private Image _background;
    private int _index;

    void Start()
    {
        _background = GetComponent<Image>();
        _index = GameManager.Instance.cutsceneBackground;
        StartCoroutine(ShowGameOverScreen());
    }

    private IEnumerator ShowGameOverScreen()
    {
        _background.sprite = endings[_index];
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MainMenu");
    }
}
