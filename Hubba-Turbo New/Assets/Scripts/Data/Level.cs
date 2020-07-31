using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Sprite levelSprite;
    public int levelNumber;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    public void SetOneStar()
    {

    }

}
