using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private GameObject[] weapons;
    private int weaponIndex = 0;

    [SerializeField]
    private Transform shootTransform; // 플레이어 머리 위로 발사되는 위치값

    [SerializeField]
    private float shootInterval = 0.05f; //미사일 쏘는 간격
    private float lastShortTime = 0f; //마지막 쏜 시간

    void Update()
    {
        //키보드로 좌우 움직이기
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector3 moveTo = new Vector3(horizontalInput, 0f, 0f); //2D라 Z값 의미X -> 0으로 지정
        transform.position += moveTo * moveSpeed * Time.deltaTime;

        Shoot();
    }

    void Shoot()
    {
        //Time.time: 게임이 시작된 이후로 현재까지 흐른 시간
        if (Time.time - lastShortTime > shootInterval)
        {
            Instantiate(weapons[weaponIndex], shootTransform.position, Quaternion.identity);
            lastShortTime = Time.time;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            GameManager.instance.SetGameOver();
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Coin")
        {
            GameManager.instance.IncreaseCoin();
            Destroy(other.gameObject);
        }
    }

    public void Upgrade()
    {
        weaponIndex += 1;
        if (weaponIndex >= weapons.Length)
        {
            weaponIndex = weapons.Length - 1;
        }
    }
}
