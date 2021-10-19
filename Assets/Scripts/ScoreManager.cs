using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private Player[] BestPlayers = new Player[3];

    

    public static ScoreManager Instance;

    public InputField inputPlayerName;
    
    public int currentPlayerScore { get;  set; } = 0;        // ENCAPSULATION
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


    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefie.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SavedScore<Player> data = JsonUtility.FromJson<SavedScore<Player>>(json);
            int i = 0;
            foreach (var player in data.BestScore)
            {
                if (player != null)
                {
                    BestPlayers[i] = player;
                    i++;
                }
                else
                {
                    BestPlayers[i].Name = "None";
                    BestPlayers[i].Score = 0;
                }
            }
        }
        else
        {
            Player newPlayer = new Player();
            newPlayer.Name = "None";
            newPlayer.Score = 0;
            for (int i = 2; i >= 0; i--)
            {
                BestPlayers[i] = newPlayer;
            }
        }
        
    }
    public void SaveBestScore()
    {
        SavedScore<Player> savedScore = new SavedScore<Player>();
        int i = 0;
        foreach (var player in BestPlayers)
        {
            if (player != null && i != 3)
            {
                savedScore.BestScore[i] = player;
                i++;
            }
        }

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", savedScore.SaveToStr());
    }

    public void ArrangeScoreList()
    {
        Player bufferPlayer = new Player();
        bufferPlayer.Name = currentPlayerName;
        bufferPlayer.Score = currentPlayerScore;
        for (int i = 2; i >= 0; i--)
        {
            if (BestPlayers[i].Score < bufferPlayer.Score)
            {
                if (i == 2)
                {
                    BestPlayers[i] = bufferPlayer;
                }
                else
                {
                    BestPlayers[i + 1] = BestPlayers[i];
                    BestPlayers[i] = bufferPlayer;
                }
            }
            
        }
    }
    
    public string ConcatText()
    {
        string text = "Your Score: " + currentPlayerScore + "\n\nBest players:\n";
        int i = 1;
        foreach (var bestPlayer in BestPlayers)
        {
            if (bestPlayer != null)
            {
                text += i + ". " + bestPlayer.Name + " - " + bestPlayer.Score + "\n";
                i++;
            }
        }

        return text;
    }
}
[System.Serializable]
class Player
{
    public string Name { get;  set; }
    public int Score { get;  set; }
}

[System.Serializable]
class SavedScore<Player>
{
    public Player[] BestScore = new Player[3];

    public string SaveToStr()
    {
        return JsonUtility.ToJson(this);
    }
}