using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameStates gameState;

    public delegate void StateSwitch();
    public event StateSwitch stateSwitched;

    private float originalTimeScale;
    public static GameManager instance;

    public AudioClip currentObjective;
    [SerializeField] private MusicManager MM;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {

        UpdateGameState(GameStates.GamePaused);
    }

    public void UpdateGameState(GameStates newState)
    {
        gameState = newState;

        switch (gameState)
        {
            case GameStates.StartUp:
                
                break;

            case GameStates.GamePaused:
                onGamePaused();
                break;


        }

        stateSwitched();
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
        MainMenu,
        GamePaused,
        Introduction,
        Objective1,
        Objective2,
        Objective3
    }
}
