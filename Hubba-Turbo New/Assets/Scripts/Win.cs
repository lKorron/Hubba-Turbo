using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] private float delay = 2f;
    private ObjectInstantiate objectInstantiate;
    private StarsPanel starsPanel;
    private Level levelInfo;
    private Timer timer;
    private Floor floor;

    private void Awake()
    {
        objectInstantiate = FindObjectOfType<ObjectInstantiate>();
        starsPanel = FindObjectOfType<StarsPanel>();
        levelInfo = FindObjectOfType<Level>();
        timer = FindObjectOfType<Timer>();
        floor = FindObjectOfType<Floor>();
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
            levelInfo.SetTwoStar();
        }
        else if (timer.IsTimerEnd == false && floor.IsWasCollision == false)
        {
            starsPanel.SetThreeStars();
            levelInfo.SetThreeStar();
        }
        else
        {
            starsPanel.SetOneStar();
            levelInfo.SetOneStar();
        }

        
    }

    private IEnumerator PauseCoroutine()
    {
        yield return new WaitForSeconds(delay);
        Time.timeScale = 0f;
    }
}
