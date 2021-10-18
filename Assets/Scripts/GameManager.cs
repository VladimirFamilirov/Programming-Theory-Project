using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Text TextEndGame;
    public Text textPlayerName;
    public int score;
    public bool isActive;
    void Start()
    {
        Instance = this;
        score = 0;
        isActive = true;
       GetPlayerName();
    }

    
    void Update()
    {
        textPlayerName.text = CurrentScoreAndName();
    }
    private string CurrentScoreAndName()
    {
        return ScoreManager.Instance.currentPlayerName + ": " + score;
    }
    private void ShowEndGameScore()
    {
        TextEndGame.text = ScoreManager.Instance.ConcatText();
        TextEndGame.gameObject.SetActive(true);
    }
    private void GetPlayerName()
    {
        textPlayerName.text = ScoreManager.Instance.currentPlayerName;
    }
}
