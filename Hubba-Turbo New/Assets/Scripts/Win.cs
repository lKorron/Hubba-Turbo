using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public void PlayerWin()
    {
        gameObject.SetActive(true);
        // freezing time
        Time.timeScale = 0f;
    }
}
