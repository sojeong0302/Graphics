using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField]
    private TextMeshProUGUI text;
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
    }
}
