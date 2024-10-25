using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float moveSpeed = 3f;
    void Update()
    {
        // 배경을 아래로 이동
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        // 배경의 Y 위치가 -10보다 작아지면
        if (transform.position.y < -10)
        {
            // 배경을 Y축으로 20만큼 위로 올림
            transform.position += new Vector3(0, 20f, 0);
        }
    }
}
