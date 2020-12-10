using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private float _waitingTime;
    [SerializeField] private GameScene _scene;

    private void Awake()
    {
        StartCoroutine(WaitForVideo());
    }
    #region
    private void OnValidate()
    {
        if (_waitingTime < 0)
            _waitingTime = 0;
    }
    #endregion
    private IEnumerator WaitForVideo()
    {
        yield return new  WaitForSeconds(_waitingTime);
        SceneManager.LoadScene(_scene.ToString());
    }
}
