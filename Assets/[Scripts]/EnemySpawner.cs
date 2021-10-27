using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public Transform[] enemyArray;
    public GameObject enemy;
    // Start is called before the first frame update

    void Start()
    {
        SpawnEnemyWave();
    }

    // Update is called once per frame

    void Update()
    {
        
    }

    public void SpawnEnemyWave()
    {
        for (int i = 0; i < enemyArray.Length; i++)
        {
            var enemySpawn = Instantiate(enemy, enemyArray[i].transform.position, Quaternion.identity);
        }
    }
}
