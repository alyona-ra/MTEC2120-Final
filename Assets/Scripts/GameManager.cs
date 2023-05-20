using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    private void Start()
    {
        Gem[] gems = FindObjectsOfType<Gem>();
        foreach (Gem gem in gems)
        {
            gem.OnGemCollected += UpdateScore;
        }
    }

    public void UpdateScore(int coinValue)
    {
        score += coinValue;
        scoreText.text = score.ToString();
    }

    public int GetScore()
    {
        return score;
    }
}
