using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]
    private TextMeshProUGUI text;

    [SerializeField]
    private GameObject gameOverPanel;
    private int coin = 0;


    //start보다 더 빠르게 호출
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void IncreaseCoin()
    {
        coin += 1;
        text.SetText(coin.ToString());

        //무기 업그레이드
        if (coin % 5 == 0)
        {
            Player player = FindObjectOfType<Player>();
            if (player != null)
            {
                player.Upgrade();
            }
        }
    }

    public void SetGameOver()
    {
        // 씬에서 EnemySpawner 컴포넌트를 가진 오브젝트를 찾아서 enemySpawner 변수에 저장
        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        if (enemySpawner != null)
        {
            // enemySpawner가 존재할 경우, 적 생성 루틴을 멈추기 위해 StopEnemyRoutine() 메서드 호출
            enemySpawner.StopEnemyRoutine();
        }
        // 0.5초 후에 ShowGameOverPanel 메서드를 호출하여 게임 오버 화면을 표시
        Invoke("ShowGameOverPanel", 0.5f);
    }

    void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    //게임 다시 시작
    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
