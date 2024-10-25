using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject coin;

    [SerializeField]
    private float moveSpeed = 10f;

    private float minY = -7f;

    [SerializeField]
    private float hp = 1f;

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

    //is trigger가 체크되어있을 경우 사용
    //enemy의 체력 감소 코드
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            Weapon weapon = other.gameObject.GetComponent<Weapon>();
            hp -= weapon.damage;

            //enemy 없어짐
            if (hp <= 0)
            {
                Destroy(gameObject);
                Instantiate(coin, transform.position, Quaternion.identity);
            }

            //미사일(weapon) 없애줌
            Destroy(other.gameObject);
        }
    }
}
