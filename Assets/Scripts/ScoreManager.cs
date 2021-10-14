using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public InputField inputPlayerName;
    
    public int currentPlayerScore { get; private set; } = 0;
    public string currentPlayerName { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }
    public void StartGame()
    {
        currentPlayerName = inputPlayerName.text;
        SceneManager.LoadScene("Game");
    }
}
class Player
{
    public string Name { get; private set; }
    public int Score { get; private set; }
}

[System.Serializable]
class SavedScore
{
    Player[] bestScore = new Player[2];
}