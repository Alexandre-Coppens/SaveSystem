using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;



[Serializable]
public class SaveData
{
    public PlayerInfo playerInfo;
    public SaveSettings settings;
    public List<EnemyInfo> enemiesInfo;
}

[Serializable]
public class sVector3
{
    public float x;
    public float y;
    public float z;
}

public class SavingSystem : MonoBehaviour
{
    public static SavingSystem instance;
    public Settings settings;
    public Player player;
    public List<Enemies> enemies;

    public GameObject enemyPrefab;

    public SaveData saveData;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) Save();
        if (Input.GetKeyDown(KeyCode.L)) Load();
    }

    void Save()
    {
        saveData.playerInfo = player.playerInfo;
        saveData.settings = settings.settingsInfo;
        foreach (Enemies e in enemies)
        {
            saveData.enemiesInfo.Add(e.enemyInfo);
        }

        string json = JsonUtility.ToJson(saveData);
        Debug.Log(json);
        SaveToFile();
    }

    private void Load()
    {
        LoadFile();
        settings.Load(saveData.settings);
        player.Load(saveData.playerInfo);
        foreach (EnemyInfo info in saveData.enemiesInfo)
        {
            Instantiate(enemyPrefab, ToVector3(info.position), Quaternion.Euler(ToVector3(info.rotation)));
        }
    }

    protected void SaveToFile()
    {
        string json = JsonUtility.ToJson(saveData);
        if (!File.Exists(Application.persistentDataPath + "/data.save"))
        {
            File.Create(Application.persistentDataPath + "/data.save").Dispose();
        }
        File.WriteAllText(Application.persistentDataPath + "/data.save", json);
    }

    protected void LoadFile()
    {
        if (File.Exists(Application.persistentDataPath + "/data.save"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/data.save");
            saveData = JsonUtility.FromJson<SaveData>(json);
        }
        else
        {
            saveData = new SaveData();
        }
    }

    public Vector3 ToVector3(sVector3 sv3)
    {
        return new Vector3(sv3.x, sv3.y, sv3.z);
    }
}
