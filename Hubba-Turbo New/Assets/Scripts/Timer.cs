using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Time before end
    [SerializeField] private float time = 10f;
    public bool IsTimerEnd { get; private set; } = false;

    private bool isTimerActive = true;

    private void Update()
    {
        if (isTimerActive)
        {
            time -= Time.deltaTime;
        }

        if (time <= 0)
        {
            IsTimerEnd = true;
            isTimerActive = false;
        }
        
    }


}
