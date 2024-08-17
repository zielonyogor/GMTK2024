using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu, levelSelector;

    private void Start()
    {
        if (GameManager.Instance.returnToLevelSelector)
        {
            LoadLevels();
        }
    }
    public void LoadLevels()
    {
        mainMenu.SetActive(false);
        levelSelector.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        mainMenu.SetActive(true);
        levelSelector.SetActive(false);
    }
    public void StartGame(int index)
    {
        GameManager.Instance.currentLevel = index;
        SceneManager.LoadScene(0);
    }
}
