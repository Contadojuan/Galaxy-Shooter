using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject Player_1;
    public GameObject Player_2;
    public bool gameOver = true;
    public UI_Manager uiManager;
    private MainMenu_Manager mainMenu;

    public int finishGameCount = 0;
    void Start()
    {

        uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
    }
    void Update()
    {
        if (gameOver == true)
        {
            StartMyGame();
        }
        if (gameOver == false)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                uiManager.EnablePauseMenu();
            }
        }


    }
    public void StartMyGame()
    {

        if (uiManager != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (GameObject.FindGameObjectWithTag("Player") != true && CheckGameMode() == "Single-Player")
                {
                    uiManager.ResetScore();
                    uiManager.title.gameObject.SetActive(false);
                    Instantiate(Player_1);
                    gameOver = false;
                }
                else if (GameObject.FindGameObjectWithTag("Player") != true && CheckGameMode() == "Co-Op")
                {
                    uiManager.ResetScore();
                    uiManager.title.gameObject.SetActive(false);
                    finishGameCount = 0;
                    Instantiate(Player_1);
                    Instantiate(Player_2);
                    gameOver = false;
                }
            }
            {
                if (gameOver == true && Input.GetKeyDown(KeyCode.Escape))
                {
                    LoadMainMenu();
                }
            }
        }
    }
    public string CheckGameMode()
    {
        Scene myScene = SceneManager.GetActiveScene();
        if (myScene.name == "Single Player mode")
        {
            return "Single-Player";
        }
        else if (myScene.name == "Co-Op mode")
        {
            Debug.Log("hey, now i'm on co-op mode!");

            return "Co-Op";
        }
        else
        {
            return null;
        }
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}

