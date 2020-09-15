using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    [SerializeField] private string _id;

    public static DontDestroyOnLoad Get(string id)
    {
        var instances = FindObjectsOfType<DontDestroyOnLoad>();
        return instances.FirstOrDefault(i => i._id == id);
    }

    private void Awake()
    {
        if (string.IsNullOrEmpty(_id))
        {
            _id = Guid.NewGuid().ToString();
        }

        var instance = Get(_id);

        if (instance != null && instance != this)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
