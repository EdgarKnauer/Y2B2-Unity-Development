using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameStates gameState;

    public delegate void StateSwitch();
    public event StateSwitch stateSwitched;

    private float originalTimeScale;
    public static GameManager instance;

    public string currentTask;
    [SerializeField] private MusicManager MM;

    private int taskIndex = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateGameState(GameStates.GamePlay);
        currentTask = "Task1";
    }

    public void UpdateGameState(GameStates newState)
    {
        gameState = newState;

        switch (gameState)
        {
            case GameStates.StartUp:                
                break;

            case GameStates.GamePlay:
                break;


        }

        stateSwitched();
    }

    public void NextTask()
    {
        taskIndex += 1;
        switch(taskIndex)
        {
            case 1: currentTask = "Task2"; break;
            case 2: currentTask = "Task3"; break;
            case 3: currentTask = "Task4"; break;
            case 4: currentTask = "Task5"; break;           
        }
    }

    public void onGamePaused()
    {
        originalTimeScale = Time.timeScale;
        Time.timeScale = 0;
    }

    public void onGameResumed()
    {
        Time.timeScale = originalTimeScale;
    }

    public void endGame()
    {
        Application.Quit();
    }

    public enum GameStates
    {
        StartUp,
        Introduction,
        MainMenu,
        GamePaused,
        GamePlay,
        Navigation,
        Objective1,
        Objective2,
        Objective3
    }
}
