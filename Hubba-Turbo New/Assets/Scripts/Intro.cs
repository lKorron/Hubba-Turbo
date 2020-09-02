using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    [SerializeField] private float waitingTime;

    private void Start()
    {
        StartCoroutine(WaitForVideo());
    }

    private IEnumerator WaitForVideo()
    {
        yield return new  WaitForSeconds(waitingTime);
        SceneManager.LoadScene(0);
        
    }
}
