using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private GameManager gameManager;


    [Header("OverlayCanvasPanels")]
    [SerializeField] private GameObject StartUpPanel;
    [SerializeField] private GameObject MainMenuPanel;
    [SerializeField] private GameObject GamePausedPanel;
    [SerializeField] private GameObject Introduction;
    [SerializeField] private GameObject Navigation;


    [Header("CurrentlyActivePanel")]
    [SerializeField] private GameObject currentUIPanel;
        

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    
    private void OnEnable()
    {
        gameManager.stateSwitched += OnGameStateChanged;
    }

    private void OnGameStateChanged()
    {
        string gameState = gameManager.gameState.ToString();
        switch (gameState)
        {
            case "StartUp":
                break;

            case "MainMenu":
                break;

            case "GamePaused":
                break;

            case "Introduction":
                break;

            case "Navigation":
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
