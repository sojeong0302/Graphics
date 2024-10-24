using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    void Update()
    {
        //키보드로 좌우 움직이기
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector3 moveTo = new Vector3(horizontalInput, 0f, 0f); //2D라 Z값 의미X -> 0으로 지정
        transform.position += moveTo * moveSpeed * Time.deltaTime;
    }
}
