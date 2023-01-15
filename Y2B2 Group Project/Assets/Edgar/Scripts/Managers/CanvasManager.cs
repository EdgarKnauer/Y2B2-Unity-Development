using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private GameManager gameManager;


    [Header("Canvas and Panels")]
    [SerializeField] private GameObject navigationCanvas;
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject gamePausedPanel;
    [SerializeField] private GameObject gamePlayPanel;
    [SerializeField] private GameObject navigationPanel;


    [Header("CurrentlyActivePanel")]
    [SerializeField] private GameObject currentUIPanel;
        

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();

        //Change this later in development!!!!
        ///////////////////////////////
        currentUIPanel = mainMenuPanel;
        ///////////////////////////////
    }

    private void OnEnable()
    {
        gameManager.stateSwitched += OnGameStateChanged;
    }

    private void Start()
    {
        mainMenuPanel.SetActive(false);
        gamePausedPanel.SetActive(false);
        navigationPanel.SetActive(false);        
    }

    private void OnGameStateChanged()
    {
        string gameState = gameManager.gameState.ToString();
        switch (gameState)
        {
            case "MainMenu":
                break;

            case "GamePaused":                
                break;

            case "GamePlay":
                ChangeUI(currentUIPanel, gamePlayPanel);
                navigationCanvas.SetActive(false);
                break;

            case "Navigation":
                ChangeUI(currentUIPanel, navigationPanel);
                navigationCanvas.SetActive(true);
                break;
        }
    }

    private void ChangeUI(GameObject oldUIPanel, GameObject newUIPanel)
    {
        oldUIPanel.SetActive(false);
        newUIPanel.SetActive(true);
        currentUIPanel = newUIPanel;
    }

    private void OnDisable()
    {
        gameManager.stateSwitched -= OnGameStateChanged;
    }


}
