using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public enum GameState
{
    RUNNING,
    PAUSED,
    EXITING
}


public class GameManager : MonoBehaviour
{
    private static GameManager instance;//singleTon Member variable

    public static GameManager Instance//singleTon access property
    {
        get { return instance; }
    }
 
    public int points = 0;
    public int health = 100;
    public bool shotFromArduinoReceived = false;
    public bool arduinoLedState = false;
   
    public static int MAXBULLETS = 5;
    public static int bulletsInMagazine = MAXBULLETS;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpsControlr;

    public static GameState currentGameState = GameState.PAUSED;
    private GameState prevGameState = GameState.RUNNING;

    private void Awake()//singleton instance creation on awake (when object is first created)
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject); //optional if it needs to exist across different scenes
    }

    // Update is called once per frame
    void Update()
    {
        if(prevGameState != currentGameState)
        {
            switch(currentGameState)
            {
                case GameState.PAUSED:
                    SetPause(true);
                    prevGameState = GameState.PAUSED;    
                    break;
                case GameState.RUNNING:
                    SetPause(false);
                    prevGameState = GameState.RUNNING;
                    break;
                case GameState.EXITING:
                    Application.Quit();//only works in build        
                    prevGameState = GameState.EXITING;
                    break;
            }
        }
    }
    public static void ReloadWeapon()
    {
        bulletsInMagazine = MAXBULLETS;
    }

    public void StartGame()
    {
        currentGameState = GameState.RUNNING;
    }
    public void ExitGame()
    {
        currentGameState = GameState.EXITING;
    }
    private void SetPause(bool isOn)
    {
        //set timeScale to 0
        if(isOn)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
            Time.timeScale = 1;
        }
    }

    public void SetArduinoLed(bool state)
    {
        arduinoLedState = state;
    }

}
