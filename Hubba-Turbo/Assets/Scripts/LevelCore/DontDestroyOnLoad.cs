using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Level))]
public class DontDestroyOnLoad : MonoBehaviour
{
    private string _id;
    private Level _level;

    public static DontDestroyOnLoad Get(string id)
    {
        var instances = FindObjectsOfType<DontDestroyOnLoad>();
        return instances.FirstOrDefault(i => i._id == id);
    }

    private void Awake()
    {
        _id = SceneManager.GetActiveScene().buildIndex.ToString();
        _level = GetComponent<Level>();
        if (string.IsNullOrEmpty(_id))
        {
            _id = Guid.NewGuid().ToString();
        }

        var instance = Get(_id);

        if (instance != null && instance != this)
        {
            Destroy(instance.gameObject);
        }
        if (_level.IsLevelOpenByPlayer)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
