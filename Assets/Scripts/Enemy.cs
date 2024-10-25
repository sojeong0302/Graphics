using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;

    private float minY = -7;

    public void SetMoveSpeed(float moveSpeed)
    {
        //this는 전역으로 지정된거
        this.moveSpeed = moveSpeed;
    }
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        //적의 위치가 minY보다 작아지면 삭제
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }
}
