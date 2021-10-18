using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text TextEndGame;
    public Text textPlayerName;
    void Start()
    {
       GetPlayerName();
    }

    
    void Update()
    {
        
    }

    private void ShowGameScore()
    {
        TextEndGame.text = ScoreManager.Instance.ConcatText();
        TextEndGame.gameObject.SetActive(true);
    }
    private void GetPlayerName()
    {
        textPlayerName.text = ScoreManager.Instance.currentPlayerName;
    }
}
