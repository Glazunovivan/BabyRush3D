using System;
using System.IO;
using UnityEngine;
public class SaveSystem : MonoBehaviour
{
    public SaveData SaveData = new SaveData();
    private string _path;

    private void Awake()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        _path = Path.Combine(Application.persistentDataPath, "Save.json");
#else
        _path = Path.Combine(Application.dataPath, "Save.json");
#endif
        if (IsFileExists())
        {
            LoadSaveFile();
        }
    }

    public void LoadSaveFile()
    {
        Debug.Log("Загружаем сохранение");
        SaveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(_path));
    }

    public void Save()
    {
        Debug.Log("Сохраняемся");
        File.WriteAllText(_path, JsonUtility.ToJson(SaveData));
    }

    public bool IsFileExists()
    {
        if (File.Exists(_path))
        {
            return true;
        }
        else
        {
            SaveData.Coins = 0;
            return false;
        }
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            Save();
        }
    }
#endif
    private void OnApplicationQuit()
    {
        Save();
    }

    public void AppQuit()
    {
        Application.Quit();
    }
}

[Serializable]
public class SaveData
{
    public uint Coins;
}

