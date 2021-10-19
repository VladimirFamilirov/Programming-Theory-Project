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
    public int gemsCount;
    public bool isActive;
    void Start()
    {
        Instance = this;
        gemsCount = 3;
        score = 0;
        isActive = true;
        GetPlayerName();
    }

    
    void Update()
    {
        textPlayerName.text = CurrentScoreAndName();
        CheckGems();
    }
    private void CheckGems()
    {
        if (gemsCount == 0)
        {
            isActive = false;
            
            //arrange score
            ShowEndGameScore();
            ScoreManager.Instance.SaveBestScore();
        }
    }
    private string CurrentScoreAndName()
    {
        return ScoreManager.Instance.currentPlayerName + ": " + score;
    }
    private void ShowEndGameScore()
    {
        ScoreManager.Instance.LoadBestScore();
        ScoreManager.Instance.currentPlayerScore = score;
        ScoreManager.Instance.ArrangeScoreList();
        TextEndGame.text = ScoreManager.Instance.ConcatText();
        TextEndGame.gameObject.SetActive(true);
        textPlayerName.gameObject.SetActive(false);
    }
    private void GetPlayerName()
    {
        textPlayerName.text = ScoreManager.Instance.currentPlayerName;
    }
}
