using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class Win : MonoBehaviour
{
    [SerializeField] private ParticleSystem _winEffect;
    [SerializeField] private float _delay = 2f;

    private Level _levelInfo;
    private Level[] _levels;
    private ObjectInstantiate _objectInstantiate;
    private StarsPanel _starsPanel;
    private Timer _timer;
    private Floor _floor;
    private int _levelNumber; // Build index

    #region OnValidate
    private void OnValidate()
    {
        if (_delay < 0)
            _delay = 0;
    }
    #endregion

    private void Awake()
    {
        _objectInstantiate = FindObjectOfType<ObjectInstantiate>();
        _starsPanel = FindObjectOfType<StarsPanel>();
        _timer = FindObjectOfType<Timer>();
        _floor = FindObjectOfType<Floor>();

        // Find current LevelInfo
        _levelNumber = SceneManager.GetActiveScene().buildIndex;
        _levels = FindObjectsOfType<Level>();
        _levelInfo = FindLevelInfo();

    }

    public void PlayerWin()
    {
        gameObject.SetActive(true);
        _winEffect.gameObject.SetActive(true);
        // Pause
        StartCoroutine(PauseCoroutine());
        _objectInstantiate.IsPlayerCanInstantiate = false;

        // Two stars processing
        if (_timer.IsTimerEnd == false ^ _floor.IsWasCollision == false)
            SetStars(2);
            
        else if (_timer.IsTimerEnd == false && _floor.IsWasCollision == false)
            SetStars(3);

        else
            SetStars(1);
    }

    private void SetStars(int starsCount)
    {
        _starsPanel.SetStars(starsCount);
        _levelInfo.SetStars(starsCount);
    }

    private Level FindLevelInfo()
    {
        var foundItem = _levels.SingleOrDefault(item => item.LevelNumber == _levelNumber);
        return foundItem;
    }

    private IEnumerator PauseCoroutine()
    {
        yield return new WaitForSeconds(_delay);
        Time.timeScale = 0f;
    }
}
