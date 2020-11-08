using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{

    private Menu menu;

    public static SaveSystem Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        menu = FindObjectOfType<Menu>();
    }
    // Save menudata info into file
    public void Save()
    {
        FileStream file = new FileStream(Application.persistentDataPath + "/Levels.dat", FileMode.OpenOrCreate);

        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(file, menu.MenuData);

        file.Close();

    }
    // Load menudata info from file
    public void Load()
    {
        FileStream file = new FileStream(Application.persistentDataPath + "/Levels.dat", FileMode.Open);
        BinaryFormatter formatter = new BinaryFormatter();
        menu.MenuData =  (MenuData)formatter.Deserialize(file);

        file.Close();

    }

    public void DeleteFile()
    {
        File.Delete(Application.persistentDataPath + "/Levels.dat");
    }

    public void FirstTimeCreate()
    {
        FileStream file = new FileStream(Application.persistentDataPath + "/Levels.dat", FileMode.OpenOrCreate);
        file.Close();
    }
}
