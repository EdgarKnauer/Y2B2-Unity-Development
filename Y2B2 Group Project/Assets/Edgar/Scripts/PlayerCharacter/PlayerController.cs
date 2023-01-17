using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [Header("Managers")]
    private GameManager gameManager;
    private MusicManager musicManager;

    [Header("ControllerSetUp")]
    [SerializeField] private PlayerInpuActions playerControls;
    private InputAction menuButton;


    [Header("GeneralSetUp")]
    private string currentGameState;
    private NavigationButtonFunctionality NBF;
    public bool openingNavigation = false;
    public bool teleporting = false;

    public GameObject grabbedObjLeftHand;
    public GameObject grabbedObjRightHand;
    public GameObject currentlyGrabbedObj;


    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        musicManager = FindObjectOfType<MusicManager>();
        NBF = FindObjectOfType<NavigationButtonFunctionality>();
    }

    private void OnEnable()
    {
        gameManager.stateSwitched += OnGameStateChanged;

        //menuButton = playerControls.Player.MenuButton;

        //menuButton.Enable();
    }

    private void Update()
    {

        //leftController.TryGetFeatureValue(CommonUsages.triggerButton, out leftButtonPressed);
        //rightController.TryGetFeatureValue(CommonUsages.triggerButton, out rightButtonPressed);
        switch (currentGameState)
        {
            case "StartUp":
                break;

            case "MainMenu":
                break;

            case "GamePaused":
                break;

            case "GamePlay":

                //Opening Navigation Menu
                //menuButton.started += _ =>
                //{
                //    gameManager.UpdateGameState(GameManager.GameStates.Navigation);
                //};

                if(Input.GetKeyUp("n"))
                {
                    StartCoroutine(OpeningNavigation());
                    Debug.Log("SwitchedGameStateGamePLay");
                    gameManager.UpdateGameState(GameManager.GameStates.Navigation);
                }
                break;

            case "Introduction":
                break;

            case "Navigation":

                //Closing Navigation Menu
                //menuButton.started += _ =>
                //{
                //    gameManager.UpdateGameState(GameManager.GameStates.GamePlay);
                //};

                if (Input.GetKeyUp("n"))
                {
                    Debug.Log("SwitchedGameStateNavigation");
                    openingNavigation = false;
                    teleporting = false;
                    gameManager.UpdateGameState(GameManager.GameStates.GamePlay);
                }
                break;
        }
    }

    
    private void OnGameStateChanged()
    {
        currentGameState = gameManager.gameState.ToString();
        switch (currentGameState)
        {
            case "StartUp":
                break;

            case "MainMenu":
                break;

            case "GamePaused":
                break;

            case "GamePlay":
                break;

            case "Introduction":
                break;

            case "Navigation":
                break;
        }
    }

    private IEnumerator OpeningNavigation()
    {
        openingNavigation = true;
        AudioClip clip = musicManager.getAudioClip("Dialogue", "NoObject");
        NBF.playClip(clip);
        yield return new WaitForSecondsRealtime(clip.length);
        openingNavigation = false;
    }

    private void OnDisable()
    {
        gameManager.stateSwitched -= OnGameStateChanged;

        //menuButton.Disable();
    }
}
