using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Variable for game end screen")]
    public int cutsceneBackground;

    [Header("Game Data")]
    public GameData gameData;
    public int currentLevel = 0;

    [Header("Other variables")]
    public bool returnToLevelSelector = false;

    private bool _collectedItem = false;

    private void Awake()
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
        gameData = SaveSystem.LoadGameData();
    }

    public void NextLevel()
    {
        if(_collectedItem)
        {
            gameData.completedWithSpecial[currentLevel] = true;
            _collectedItem = false;
        }

        if (currentLevel == gameData.level - 1)
        {
            gameData.level++;
        }

        if (gameData.level > Constants.maxLevel)
        {
            SaveSystem.DeleteSaveFile();
            cutsceneBackground = 2;
            returnToLevelSelector = false;
            SceneManager.LoadScene("Cutscene");
            return;
        }

        SceneManager.LoadScene("MainMenu");
        SaveSystem.SaveGame();
    }

    public void GameOver(Constants.GameEndState state)
    {
        if (state == Constants.GameEndState.PlayerTooBig)
        {
            Debug.Log("you grew too big");
            cutsceneBackground = 0;
            SceneManager.LoadScene("Cutscene");
        }
        else
        {
            Debug.Log("you were shrank into the atoms");
            cutsceneBackground = 1;
            SceneManager.LoadScene("Cutscene");
        }
    }

    public void CountSpecialItem()
    {
        _collectedItem = true;
    }
}
