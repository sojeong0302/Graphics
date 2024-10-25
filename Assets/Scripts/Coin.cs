using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float minY = -7f;
    void Start()
    {
        Jump();
    }
    void Jump()
    {
        // 현재 게임 오브젝트의 Rigidbody2D 컴포넌트를 가져옴
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        // 4f에서 8f 사이의 랜덤 점프 힘을 생성
        float randomJumpForce = UnityEngine.Random.Range(4f, 8f);

        // 동전을 위로 이동시키는 속도 벡터 생성
        Vector2 jumpVelocity = Vector2.up * randomJumpForce;

        // 동전의 좌우 이동 속도를 랜덤으로 설정
        jumpVelocity.x = UnityEngine.Random.Range(-2f, 2f);

        // 생성된 점프 속도로 동전에게 힘을 가함
        rigidbody.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }

    void Update()
    {
        // 동전의 Y 위치가 minY보다 작아지면
        if (transform.position.y < minY)
        {
            // 동전을 삭제
            Destroy(gameObject);
        }
    }
}
