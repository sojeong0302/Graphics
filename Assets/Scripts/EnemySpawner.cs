using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    private float[] arrPosX = { -2.2f, -1.1f, 0f, 1.1f, 2.2f }; //무기 x좌표값
    void Start()
    {
        foreach (float PosX in arrPosX)
        {
            int index = UnityEngine.Random.Range(0, enemies.Length);
            SpawnEnemy(PosX, index);
        }
    }

    void SpawnEnemy(float posX, int index)
    {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);
        Instantiate(enemies[index], spawnPos, quaternion.identity);
    }
}
