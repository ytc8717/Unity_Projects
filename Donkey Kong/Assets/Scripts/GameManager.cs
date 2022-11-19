using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int level;
    private int lives;
    private int score;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        NewGame();
    }

    private void NewGame()
    {
        lives = 3;
        score = 0;

        // Load level...
        LoadLevel(1);
    }

    private void LoadLevel(int index)
    {
        level = index;

        Camera cam = Camera.main;

        if(cam != null)
        {
            cam.cullingMask = 0;
        }

        Invoke(nameof(LoadScene), 1f);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(level);
    }

    public void LevelComplete()
    {
        score += 1000;

        // Load next level...
        int nextLevel = level + 1;

        if(nextLevel < SceneManager.sceneCountInBuildSettings)
        {
            LoadLevel(nextLevel);
        }
        else
        {
            LoadLevel(1);
        }
    }

    public void LevelFailed()
    {
        lives--;

        if(lives == 0)
        {
            NewGame();
        }
        else
        {
            // Reload current level...
            LoadLevel(level);
        }
    }
}
