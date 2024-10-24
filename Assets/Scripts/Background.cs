using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float moveSpeed = 3f; // 3f는 실수값이라 뒤에 f붙임
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        //background 위로 올려줌
        if (transform.position.y < -10) { transform.position += new Vector3(0, 20f, 0); }
    }
}
