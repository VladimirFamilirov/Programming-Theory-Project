using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public InputField inputPlayerName;
    public void LoadGame()
    {
        ScoreManager.Instance.currentPlayerName = inputPlayerName.text;
        SceneManager.LoadScene("Game");
    }
}
