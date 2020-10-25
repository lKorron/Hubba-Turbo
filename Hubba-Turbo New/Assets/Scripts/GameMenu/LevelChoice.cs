using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChoice : MonoBehaviour
{
    [SerializeField] private GameObject _loadScreen;
    // load level menu
    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void LoadStartScreen()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadZoneMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Zones");
    }
    // load level by index
    public void LoadLevel(int level)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(level);
        SceneManager.LoadScene("Interface", LoadSceneMode.Additive);
    }
    public void LoadLevelWithLoadScreen(int level)
    {
        _loadScreen.SetActive(true);
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(level);
        SceneManager.LoadScene("Interface", LoadSceneMode.Additive);
    }
    // reload current level
    public void ReloadLevel()
    {
        Time.timeScale = 1f;
        Scene scene = SceneManager.GetActiveScene();
        int index = scene.buildIndex;
        SceneManager.LoadScene(index);
        SceneManager.LoadScene("Interface", LoadSceneMode.Additive);
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        Scene scene = SceneManager.GetActiveScene();
        int index = scene.buildIndex;
        SceneManager.LoadScene(index + 1);
        SceneManager.LoadScene("Interface", LoadSceneMode.Additive);
    }
}


