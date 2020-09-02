using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    [SerializeField] private float waitingTime = 5f;

    private void Start()
    {
        StartCoroutine(WaitForVideo());
    }

    private IEnumerator WaitForVideo()
    {
        yield return new  WaitForSeconds(waitingTime);
        
    }
}
