using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameCompletedMenu : MonoBehaviour
{
    [SerializeField] int playerScore;
    [SerializeField] TMP_Text scoreText;
    //opens the scene to level1
    private void Start()
    {
        playerScore = PersistentData.Instance.GetScore();
        scoreText.text = "Your Score: "+ playerScore;
    }
    
    
    public void PlayGameAgain()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void ShowLeaderBoard()
    {
        SceneManager.LoadScene("Leaderboard");
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
