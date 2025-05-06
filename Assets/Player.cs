using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerInfo
{
    public List<string> items;
    public int level;
    public string name;
    public float stat1;
    public float stat2;
    public float stat3;
    public float stat4;
}

public class Player : MonoBehaviour
{
    public PlayerInfo playerInfo;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Load(PlayerInfo newInfo)
    {
        playerInfo = newInfo;
    }
}
