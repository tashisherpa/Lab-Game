using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    //opens the scene to level1
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }
    //opens the instruction screen
    public void ShowInstruction()
    {
        SceneManager.LoadScene("Instructions");
    }

    //opens the settings screen
    public void ShowSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void ShowLeaderBoard()
    {
        SceneManager.LoadScene("Leaderboard");
    }

}
