using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int _currentLevelIndex = 0;
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
    }

    public void NextLevel()
    {
        _currentLevelIndex++;
        Debug.Log("player finished this level, next level: " + _currentLevelIndex);
    }

    public void GameOver(Constants.GameOverState state)
    {
        if (state == Constants.GameOverState.PlayerTooBig)
        {
            Debug.Log("you grew too big");
        }
        else
        {
            Debug.Log("you were shrank into the atoms");
            SceneManager.LoadScene(0);
        }
    }
}
