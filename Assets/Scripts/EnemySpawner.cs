using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    private float[] arrPosX = { -2.2f, -1.1f, 0f, 1.1f, 2.2f }; //무기 x좌표값

    [SerializeField]
    private float spawnInterval = 1.5f;
    void Start()
    {
        StartEnemyRoutine();
    }

    void StartEnemyRoutine()
    {
        StartCoroutine("EnemyRoutine");
    }

    public void StopEnemyRoutine()
    {
        StopCoroutine("EnemyRoutine");
    }

    IEnumerator EnemyRoutine()
    {
        yield return new WaitForSeconds(3f); //3초 기다림

        float moveSpeed = 5f;
        int spawmCount = 0;
        int enemyIndex = 0;

        //while로 무한반복
        while (true)
        {
            //5개의 enemy 생성
            foreach (float PosX in arrPosX)
            {
                SpawnEnemy(PosX, enemyIndex, moveSpeed);
            }

            spawmCount++;

            //enemy 레벨 상승
            if (spawmCount % 10 == 0) //10, 20, 30 ...
            {
                enemyIndex += 1;
                moveSpeed += 2;
            }

            yield return new WaitForSeconds(spawnInterval); //spawnInterval만큼 기다림
        }

    }

    void SpawnEnemy(float posX, int index, float moveSpeed)
    {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);

        //랜덤의 확률로 더 강한 enemy 생성
        if (UnityEngine.Random.Range(0, 5) == 0)
        {
            index += 1;
        }

        //enemy가 7까지 있기 떄문에 7이상일 경우에 에러남, 그래서 1빼줌
        if (index >= enemies.Length)
        {
            index = enemies.Length - 1;
        }

        GameObject enemyObject = Instantiate(enemies[index], spawnPos, quaternion.identity);
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        enemy.SetMoveSpeed(moveSpeed);
    }
}
