using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject myPlayer;
    public bool gameOver = true;
    public UI_Manager uiManager;
	void Start()
	{
		uiManager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
	}
	void Update()
	{	
		if (gameOver == true){
			StartMyGame();
		}
		
	}
	    public void StartMyGame()
    {

        if (uiManager != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (GameObject.FindGameObjectWithTag("Player") != true)
                {	
					uiManager.ResetScore();
                    uiManager.title.gameObject.SetActive(false);
                    Instantiate(myPlayer);
					gameOver = false;
                }
            }
        }
    }

}

