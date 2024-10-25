using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void Start()
    {
        Jump();
    }

    void Jump()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();


        float randomJumpForce = UnityEngine.Random.Range(4f, 8f);

        //coin 위로 이동
        Vector2 jumpVelocity = Vector2.up * randomJumpForce;

        //coin 좌우 이동
        jumpVelocity.x = UnityEngine.Random.Range(-2f, 2f);

        rigidbody.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }

    void Update()
    {

    }
}
