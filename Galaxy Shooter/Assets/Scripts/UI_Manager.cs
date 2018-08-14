using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Sprite[] lives;
    public Image livesImageDisplay;
    public Image title;
    private int score;
    public Text scoreText;


    public void UpdateLives(int currentLives)
    {
        livesImageDisplay.sprite = lives[currentLives];
    }

    public void UpdateScore()
    {
        score += 10;
        scoreText.text = "Score: " + score;
    }
    public void ResetScore(){
        this.score = 0;
        scoreText.text = "Score: "+score;
    }
}




