using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;
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
        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        if (enemySpawner != null)
        {
            enemySpawner.StopEnemyRoutine();
        }
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
