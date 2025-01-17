﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{

    private Menu _menu;

    public static SaveSystem Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        _menu = FindObjectOfType<Menu>();
    }
    // Save menudata info into file
    public void Save()
    {
        FileStream file = new FileStream(Application.persistentDataPath + "/Levels.dat", FileMode.OpenOrCreate);

        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(file, _menu.MenuData);

        file.Close();

    }
    // Load menudata info from file
    public void Load()
    {
        FileStream file = new FileStream(Application.persistentDataPath + "/Levels.dat", FileMode.Open);
        BinaryFormatter formatter = new BinaryFormatter();
        _menu.MenuData =  (MenuData)formatter.Deserialize(file);
        file.Close();

    }

    public void DeleteFile()
    {
        File.Delete(Application.persistentDataPath + "/Levels.dat");
    }

    public bool FirstTimeCreate()
    {
        try
        {
            FileStream file = new FileStream(Application.persistentDataPath + "/Levels.dat", FileMode.Open);
            file.Close();
            return false;
        }
        catch (System.Exception ex)
        {
            FileStream file = new FileStream(Application.persistentDataPath + "/Levels.dat", FileMode.OpenOrCreate);
            file.Close();
            return true;
        }
        
        
    }
}
