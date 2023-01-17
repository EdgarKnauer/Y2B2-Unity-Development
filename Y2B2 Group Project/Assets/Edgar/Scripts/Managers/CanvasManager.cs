using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private GameManager gameManager;


    [Header("Canvas and Panels")]
    [SerializeField] private GameObject navigationCanvas;


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

    private void Start()
    {
        navigationCanvas.SetActive(false);        
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
                navigationCanvas.SetActive(false);
                break;

            case "Navigation":
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
