using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChoice : MonoBehaviour
{
    // load main menu
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    // load level by index
    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
    // reload current level
    public void ReloadLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        int index = scene.buildIndex;
        SceneManager.LoadScene(index);
    }

    public void NextLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        int index = scene.buildIndex;
        SceneManager.LoadScene(index + 1);
    }
}
