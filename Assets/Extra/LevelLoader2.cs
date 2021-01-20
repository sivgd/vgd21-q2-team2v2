using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader2 : MonoBehaviour
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
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetSceneAt(SceneManager.GetActiveScene().buildIndex + 1).name));
    }

    IEnumerator LoadLevel(string levelName)
    {
        //Play animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Load Scene
        SceneManager.LoadScene(levelName);
    }

    public void LoadCredits()
    {
        LoadLevel("Credits");
    }
    public void LoadLevel1()
    {
        LoadLevel("Level1");
    }
}
