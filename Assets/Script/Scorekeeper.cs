using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Scorekeeper : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text sceneText;
    [SerializeField] TMP_Text nameText;
    [SerializeField] int level;

    public const int DEFAULT_POINTS = 1;
 
    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex - 1;
        score = PersistentData.Instance.GetScore();
        DisplayName();
        DisplayScene();
        DisplayScore();
    }

    public void AddPoints(int points)
    {
        score += points;
        PersistentData.Instance.SetScore(score);
        DisplayScore();
    }

    public void AddPoints()
    {
        AddPoints(DEFAULT_POINTS);

    }

    private void DisplayName()
    {
        nameText.SetText("Hi, " + PersistentData.Instance.GetName() + "!");
    }

    private void DisplayScore()
    {
        scoreText.SetText("Score: " + score);
    }

    private void DisplayScene()
    {
        sceneText.SetText("Level: " + level);
    }
}
