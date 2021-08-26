using System;
using System.IO;
using UnityEngine;
public class SaveSystem : MonoBehaviour
{
    public SaveData SaveData = new SaveData();
    private string _path;

    private void Start()
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

        DontDestroyOnLoad(this);
    }

    public void LoadSaveFile()
    {
        Debug.Log("Загружаем сохранение");
        SaveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(_path));
    }

    public void Save()
    {
        Debug.Log("Сохраняемся");
        SaveData.Coins = FindObjectOfType<Coins>().AmountCoins;
        File.WriteAllText(_path, JsonUtility.ToJson(SaveData));
    }

    public bool IsFileExists()
    {
        if (File.Exists(_path))
        {
            Debug.Log("Файл есть");
            return true;
        }
        else
        {
            SaveData.Coins = 0;
            Debug.Log("Файла нет");
            return false;
        }
    }

#if UNITY_ANDROID && !UNITY_EDITOR
    //private void OnApplicationPause(bool pause)
    //{
    //    if (pause)
    //    {
    //        Save();
    //    }
    //}
#endif
    //private void OnApplicationQuit()
    //{
    //    Save();
    //}

    public void AppQuit()
    {
        Application.Quit();
    }

    private void OnDestroy()
    {
        Save();
    }
}

[Serializable]
public class SaveData
{
    public uint Coins;
}

