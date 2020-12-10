using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject _loadScreen;

    public static SceneLoader Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    // load level menu
    public void LoadScene(string sceneName)
    {
        LoadMenuElements(sceneName);
    }

    public void LoadMenu()
    {
        LoadMenuElements(GameScene.Menu);
    }

    public void LoadStartScreen()
    {
        LoadMenuElements(GameScene.StartScreen);
    }

    public void LoadZoneMenu()
    {
        LoadMenuElements(GameScene.Zones);
    }

    // load level by index
    public void LoadLevel(int level)
    {
        LoadLevelElements(level);
    }

    public void LoadLevelWithLoadScreen(int level)
    {
        _loadScreen.SetActive(true);
        LoadLevelElements(level);
    }

    // reload current level
    public void ReloadLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        int index = scene.buildIndex;
        LoadLevelElements(index);
       
    }

    public void NextLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        int index = scene.buildIndex;
        LoadLevelElements(index + 1);
    }

    private void LoadLevelElements(int index)
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(index);
        string name = GameScene.Interface.ToString();
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
    }

    private void LoadMenuElements(GameScene gameScene)
    {
        Time.timeScale = 1f;
        name = gameScene.ToString();
        SceneManager.LoadScene(name);
    }
    private void LoadMenuElements(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

}


