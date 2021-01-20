using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public bool levelFinished = false;

    // Update is called once per frame
    void Update()
    {
        if (levelFinished)
        {
            LoadNextLevel();
            levelFinished = false;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            LoadCredits();
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
}

    
