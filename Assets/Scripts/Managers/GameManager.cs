using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    menu,
    inGame,
    pause,
    gameOver
}

public class GameManager : MonoBehaviour
{
    public GameState currentGameState = GameState.menu;
    public static GameManager sharedInstance;
    //private PlayerController controller;

    public bool gameRunning = true;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //controller = GameObject.FindWithTag("Player").GetComponent<PlayerConroller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Submit") && currentGameState != GameState.inGame)
        {
            StartGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeGameRunningState();
        }
    }

    // Zona para poner en que estado de juego se está
    public void StartGame()
    {
        SetGameState(GameState.inGame);
    }

    public void Pause()
    {
        SetGameState(GameState.pause);
    }

    public void gameOver()
    {
        SetGameState(GameState.gameOver);
    }

    private void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.inGame)
        {
            MenuManager.sharedInstance.ShowgameCanvas();
            MenuManager.sharedInstance.HaidgameOverCanvas();
            MenuManager.sharedInstance.HaidpauseCanvas();

        }
        else if (newGameState == GameState.gameOver)
        {
            // TODO: Preparar el juego para el Game Over
            MenuManager.sharedInstance.HaidgameCanvas();
            MenuManager.sharedInstance.ShowgameOverCanvas();
            MenuManager.sharedInstance.HaidpauseCanvas();
        }
        else if (newGameState == GameState.pause)
        {
            // TODO: Preparar el juego para el Game Over
            MenuManager.sharedInstance.HaidgameCanvas();
            MenuManager.sharedInstance.HaidgameOverCanvas();
            MenuManager.sharedInstance.ShowpauseCanvas();
        }

        this.currentGameState = newGameState;
    }


    // Zona para poder pausar el juego con un cambio de variables
    public void ChangeGameRunningState()
    {
        gameRunning = !gameRunning;

        if (gameRunning)
        {
            Time.timeScale = 1f;
            MenuManager.sharedInstance.HaidpauseCanvas();
            MenuManager.sharedInstance.ShowgameCanvas();

        }
        else
        {
            Time.timeScale = 0f;
            MenuManager.sharedInstance.HaidgameCanvas();
            MenuManager.sharedInstance.ShowpauseCanvas();
        }

    }
}
