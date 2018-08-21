using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Sprite[] lives;
    public Image livesImageDisplay;
    public Sprite[] livesP2;
    public Image livesImageDisplayP2;
    public Image title;
    private int score;
    private int maxScore;
    public Text scoreText;
    public Text maxScoreText;
    [SerializeField]
    private GameObject pauseMenu;
    private Animator _pauseMenuAnimation;

    void Start()
    {
        _pauseMenuAnimation = GameObject.Find("Pause_Menu").GetComponent<Animator>();
        _pauseMenuAnimation.updateMode = AnimatorUpdateMode.UnscaledTime;
        Time.timeScale = 1;
        maxScore = PlayerPrefs.GetInt("HighScore", maxScore);
        maxScoreText.text = "Max Score: " + maxScore;

    }

    public void UpdateLives(int currentLives)
    {
        livesImageDisplay.sprite = lives[currentLives];
    }
    public void UpdateLivesP2(int currentLivesP2)
    {
        livesImageDisplayP2.sprite = livesP2[currentLivesP2];
    }
    public void UpdateScore()
    {
        score += 10;
        scoreText.text = "Score: " + score;
        if (this.score > this.maxScore)
        {
            maxScore = score;
            maxScoreText.text = "Max Score: " + maxScore;
            PlayerPrefs.SetInt("HighScore", maxScore);
        }
    }
    public void ResetScore()
    {

        this.score = 0;
        scoreText.text = "Score: " + score;
    }
    public void EnablePauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        _pauseMenuAnimation.SetBool("isPaused", true);
    }
    public void DisablePauseMenu()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        _pauseMenuAnimation.SetBool("isPaused", false);

    }
}