using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenu : MonoBehaviour
{
    [SerializeField] TMP_InputField nameInput;
    //opens the scene to level1
    public void PlayGame()
    {
        PersistentData.Instance.SetName(nameInput.text);
        SceneManager.LoadScene("Level 1");
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
