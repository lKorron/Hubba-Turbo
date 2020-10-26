using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class Win : MonoBehaviour
{
    [SerializeField] private float delay = 2f;
    private Level levelInfo;
    private Level[] levels;
    private ObjectInstantiate objectInstantiate;
    private StarsPanel starsPanel;
    private Timer timer;
    private Floor floor;
    private int levelNumber; // Build index

    private void Awake()
    {
        objectInstantiate = FindObjectOfType<ObjectInstantiate>();
        starsPanel = FindObjectOfType<StarsPanel>();
        timer = FindObjectOfType<Timer>();
        floor = FindObjectOfType<Floor>();

        // Find current LevelInfo
        levelNumber = SceneManager.GetActiveScene().buildIndex;
        levels = FindObjectsOfType<Level>();
        levelInfo = FindLevelInfo();

    }

    public void PlayerWin()
    {
        gameObject.SetActive(true);
        // Pause
        StartCoroutine(PauseCoroutine());
        objectInstantiate.IsPlayerCanInstantiate = false;

        // Two stars processing
        if (timer.IsTimerEnd == false ^ floor.IsWasCollision == false)
        {
            starsPanel.SetTwoStars();
            levelInfo.SetStars(2);
            
        }
        else if (timer.IsTimerEnd == false && floor.IsWasCollision == false)
        {
            starsPanel.SetThreeStars();
            levelInfo.SetStars(3);
        }
        else
        {
            starsPanel.SetOneStar();
            levelInfo.SetStars(1);
        }

        
    }

    private Level FindLevelInfo()
    {
        var foundItem = levels.SingleOrDefault(item => item.LevelNumber == levelNumber);
        return foundItem;
    }

    private IEnumerator PauseCoroutine()
    {
        yield return new WaitForSeconds(delay);
        Time.timeScale = 0f;
    }
}
