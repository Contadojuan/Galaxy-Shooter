using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Manager : MonoBehaviour
{
    public void LoadSinglePlayer()
    {
        SceneManager.LoadScene("Single Player mode");
    }
    public void LoadCoOp()
    {
        SceneManager.LoadScene("Co-Op mode");
    }
}
