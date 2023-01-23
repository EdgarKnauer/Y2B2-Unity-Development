using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using Unity.XR.CoreUtils;


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

    [SerializeField] private GameObject leftHand;
    [SerializeField] private GameObject rightHand;

    private Vector2 inputAxis;
    [SerializeField] XRNode leftController;
    [SerializeField] private XROrigin rig;
    [SerializeField] private float movementSpeed = 2f;

    private bool MBPressed;
    public bool checkBool1;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        musicManager = FindObjectOfType<MusicManager>();
        NBF = FindObjectOfType<NavigationButtonFunctionality>();
    }        

    private void OnEnable()
    {
        gameManager.stateSwitched += OnGameStateChanged;
        DeActivateLineRenderers(false);

        //menuButton = playerControls.Player.MenuButton;

        //menuButton.Enable();
    }

    private void Update()
    {
        UnityEngine.XR.InputDevice leftControllerDevice = InputDevices.GetDeviceAtXRNode(leftController);
        leftControllerDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out inputAxis);
        leftControllerDevice.TryGetFeatureValue(UnityEngine.XR.CommonUsages.menuButton, out MBPressed);

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
                if(MBPressed && checkBool1)
                {
                    checkBool1 = false;
                    StartCoroutine(OpeningNavigation());
                    Debug.Log("SwitchedGameStateGamePLay");
                    DeActivateLineRenderers(true);
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

                if (MBPressed && checkBool1)
                {
                    checkBool1 = false;
                    StartCoroutine(ClosingNavigation());
                    Debug.Log("SwitchedGameStateNavigation");
                    DeActivateLineRenderers(false);
                    gameManager.UpdateGameState(GameManager.GameStates.GamePlay);
                }
                break;
        }

        Quaternion headDirection = Quaternion.Euler(0, rig.Camera.transform.eulerAngles.y, 0);
        Vector3 direction = headDirection * new Vector3(inputAxis.x, 0, inputAxis.y);
        rig.transform.Translate(direction * Time.deltaTime * movementSpeed);

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
        checkBool1 = true;
    }

    private IEnumerator ClosingNavigation()
    {
        yield return new WaitForSecondsRealtime(1);
        teleporting = false;
        openingNavigation = false;
        checkBool1 = true;
    }

    public void DeActivateLineRenderers(bool activate)
    {
        if (activate)
        {
            leftHand.GetComponent<UnityEngine.XR.Interaction.Toolkit.XRInteractorLineVisual>().lineLength = 10;
            rightHand.GetComponent<UnityEngine.XR.Interaction.Toolkit.XRInteractorLineVisual>().lineLength = 10;
        }
        else
        {
            leftHand.GetComponent<UnityEngine.XR.Interaction.Toolkit.XRInteractorLineVisual>().lineLength = 0;
            rightHand.GetComponent<UnityEngine.XR.Interaction.Toolkit.XRInteractorLineVisual>().lineLength = 0;
        }
    }

    private void OnDisable()
    {
        gameManager.stateSwitched -= OnGameStateChanged;

        //menuButton.Disable();
    }
}
