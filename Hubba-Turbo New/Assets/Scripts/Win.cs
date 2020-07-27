using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] private float delay = 2f;

    public void PlayerWin()
    {
        gameObject.SetActive(true);
        // Pause
        StartCoroutine(PauseCoroutine());
        
        
    }

    private IEnumerator PauseCoroutine()
    {
        yield return new WaitForSeconds(delay);
        Time.timeScale = 0f;
    }
}
