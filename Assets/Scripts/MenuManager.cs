using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu, levelSelector, cutscene;

    private void Start()
    {
        if (GameManager.Instance.returnToLevelSelector)
        {
            LoadLevels();
        }
    }
    public void LoadLevels()
    {
        if (GameManager.Instance.gameData.sawCutscene)
        {
            mainMenu.SetActive(false);
            levelSelector.SetActive(true);

        }
        else
        {
            StartCoroutine(PlayCutscene());
        }
    }

    public void ReturnToMainMenu()
    {
        mainMenu.SetActive(true);
        levelSelector.SetActive(false);
    }
    public void StartGame(int index)
    {
        GameManager.Instance.returnToLevelSelector = true;
        GameManager.Instance.currentLevel = index;
        SceneManager.LoadScene("Level_" + index.ToString()); //needs to be change to "Level_" + index
    }

    private IEnumerator PlayCutscene()
    {
        cutscene.SetActive(true);
        
        Animator animator = cutscene.GetComponent<Animator>();

        while (animator && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.99f)
            yield return null;

        GameManager.Instance.gameData.sawCutscene = true;

        levelSelector.SetActive(true);
        cutscene.SetActive(false);
        mainMenu.SetActive(false);
    }
}
