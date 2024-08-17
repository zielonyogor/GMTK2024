using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Variable for game over screen")]
    public int cutsceneBackground;

    [Header("Game Data")]
    public GameData gameData;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        gameData = SaveSystem.LoadGameData();
    }

    public void NextLevel()
    {
        gameData.level++;
        Debug.Log("player finished this level, next level: " + gameData.level);
        SceneManager.LoadScene("MainMenu");
        SaveSystem.SaveGame();
    }

    public void GameOver(Constants.GameOverState state)
    {
        if (state == Constants.GameOverState.PlayerTooBig)
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
}
