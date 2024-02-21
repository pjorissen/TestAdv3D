using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject HUD;
    public GameObject pauseMenu;
   
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.currentGameState = GameState.PAUSED;
        }    
        switch (GameManager.currentGameState)
        {      
            case GameState.PAUSED:         
                HUD.SetActive(false);
                pauseMenu.SetActive(true);
                break;
            case GameState.RUNNING:
                HUD.SetActive(true);
                pauseMenu.SetActive(false);
                break;
        }
    }


}
