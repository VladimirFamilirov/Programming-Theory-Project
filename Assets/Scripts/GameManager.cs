using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text textPlayerName;
    void Start()
    {
        GetPlayerName();
    }

    
    void Update()
    {
        
    }

    private void GetPlayerName()
    {
        textPlayerName.text = ScoreManager.Instance.currentPlayerName;
    }
}
