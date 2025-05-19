using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyInfo
{
    public string name;
    public sVector3 position;
    public sVector3 rotation;
}

public class Enemies : MonoBehaviour
{
    public EnemyInfo enemyInfo;
    void Start()
    {
        enemyInfo.name = gameObject.name;
        enemyInfo.position = TosVector3(transform.position);
        enemyInfo.rotation = TosVector3(transform.rotation.eulerAngles);
        SavingSystem.instance.enemies.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        SavingSystem.instance.enemies.Remove(this);
        Destroy(gameObject);
    }

    public sVector3 TosVector3(Vector3 v)
    {
        sVector3 sVector = new sVector3();
        sVector.x = v.x;
        sVector.y = v.y;
        sVector.z = v.z;
        return sVector;
    }
}
