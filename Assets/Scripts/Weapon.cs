using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] //유니티에게 접근 가능하게 해줌
    private float moveSpeed = 10; //private 다른 클래스에서 접근x

    void Start()
    {
        //1초 뒤 삭제
        Destroy(gameObject, 1f);
    }
    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }
}
