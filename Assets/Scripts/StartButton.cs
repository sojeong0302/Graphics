using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    void Update()
    {
        //0은 마우스 왼쪽 버튼을 의미
        if (Input.GetMouseButtonDown(0))
        {
            //SampleScene으로 씬 전환
            SceneManager.LoadScene("SampleScene");
        }
    }
}
