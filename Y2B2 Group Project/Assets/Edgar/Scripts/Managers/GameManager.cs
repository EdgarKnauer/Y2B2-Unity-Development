using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameStates gameStates;

    public delegate void StateSwitch();
    public static event StateSwitch StateSwitched;
    private float originalTimeScale;
    public static GameManager instance;

    public AudioClip currentObjective;
    [SerializeField] private MusicManager MM;

    private void Awake()
    {
        instance = this;
        //UpdateGameState(GameStates.GamePaused);
    }

    private void Start()
    {
        //Just for initial testing
        //currentObjective = SM.getAudioClip("Dialogue", "CurrentObjectiveTest");
    }

    public void UpdateGameState(GameStates newState)
    {
        gameStates = newState;
        //switch (gameStates)
        //{
        //    case GameStates.GamePaused:
        //        onGamePaused();
        //        + currentObjective = SM.getAudioClip();
        //        break;


        //}
        StateSwitched();
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
        MainMenu,
        Introduction,
        Navigation,
        Objective1,
        Objective2,
        Objective3
    }
}
