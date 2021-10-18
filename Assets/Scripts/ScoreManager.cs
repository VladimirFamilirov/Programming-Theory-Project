using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private Player[] BestPlayers = new Player[3];

    public Text TextEndGame;

    public static ScoreManager Instance;

    public InputField inputPlayerName;
    
    public int currentPlayerScore { get; private set; } = 0;        // ENCAPSULATION
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
        LoadBestScore();

    }
    public void StartGame()
    {
        currentPlayerName = inputPlayerName.text;
        SceneManager.LoadScene("Game");
    }
    private void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefie.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SavedScore data = JsonUtility.FromJson<SavedScore>(json);
            int i = 0;
            foreach (var player in data.BestScore)
            {
                if (player != null)
                {
                    BestPlayers[i] = player;
                    i++;
                }
            }
        }
        
    }
    private void SaveBestScore()
    {
        SavedScore savedScore = new SavedScore();
        int i = 0;
        foreach (var player in BestPlayers)
        {
            if (i != 3)
            {
                savedScore.BestScore[i] = player;
                i++;
            }
        }
    }
    private void ShowGameScore()
    {
       TextEndGame.text = ConcatText();
       TextEndGame.gameObject.SetActive(true);
    }
    private string ConcatText()
    {
        string text = "Your Score: " + currentPlayerScore + "\n\nBest players:\n";
        int i = 1;
        foreach (var bestPlayer in BestPlayers)
        {
            if (bestPlayer != null)
            {
                text += i + ". " + bestPlayer.Name + " - " + bestPlayer.Score;
                i++;
            }
        }

        return text;
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
    public Player[] BestScore;
}