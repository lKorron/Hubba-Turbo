using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] private float delay = 2f;
    private ObjectInstantiate objectInstantiate;

    private void Awake()
    {
        objectInstantiate = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ObjectInstantiate>();
    }

    public void PlayerWin()
    {
        gameObject.SetActive(true);
        // Pause
        StartCoroutine(PauseCoroutine());
        objectInstantiate.IsPlayerCanInstantiate = false;
        
    }

    private IEnumerator PauseCoroutine()
    {
        yield return new WaitForSeconds(delay);
        Time.timeScale = 0f;
    }
}
