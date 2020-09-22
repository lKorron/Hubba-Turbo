using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    [SerializeField] private float _waitingTime;
    [SerializeField] private SceneName scene;

    private void Start()
    {
        StartCoroutine(WaitForVideo());
    }
    #region
    private void OnValidate()
    {
        if (_waitingTime < 0) _waitingTime = 0;
    }
    #endregion
    private IEnumerator WaitForVideo()
    {
        yield return new  WaitForSeconds(_waitingTime);
        SceneManager.LoadScene(scene.ToString());
        
    }
}

public enum SceneName
{
    MainMenu,
    Zones
}
