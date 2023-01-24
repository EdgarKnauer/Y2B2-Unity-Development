using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationButtonFunctionality : MonoBehaviour
{
    [SerializeField] private List<Transform> navigationLocations;
    [SerializeField] private PlayerController player;

    public GameManager gameManager;

    [SerializeField] private Camera cam;

    [SerializeField] private Canvas playerCanvas;
    [SerializeField] private MusicManager musicManager;

    public AudioClip currentClip;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void OnWorktableButtonClicked()
    {
        if (!player.teleporting && !player.openingNavigation)
        {
            player.teleporting = true;
            StopAllCoroutines();
            StartCoroutine(ScreenFader(navigationLocations[0]));
        }
    }

    public void OnShelfButtonClicked()
    {
        if(!player.teleporting && !player.openingNavigation)
        {
            player.teleporting = true;
            StopAllCoroutines();
            StartCoroutine(ScreenFader(navigationLocations[2]));
        }        
    }

    public void OnSafetyEquipButtonClicked()
    {
        if (!player.teleporting && !player.openingNavigation)
        {
            player.teleporting = true;
            StopAllCoroutines();
            StartCoroutine(ScreenFader(navigationLocations[1]));
        }
    }

    IEnumerator ScreenFader(Transform teleportLocation)
    {        
        cam.GetComponent<Unity.XR.PXR.PXR_ScreenFade>().StartScreenFade(0, 1);
        yield return new WaitForSeconds(cam.GetComponent<Unity.XR.PXR.PXR_ScreenFade>().gradientTime);

        player.transform.position = teleportLocation.position;

        gameManager.UpdateGameState(GameManager.GameStates.GamePlay);
        player.StartClosingNavigation();

        player.transform.rotation = teleportLocation.rotation;

        cam.GetComponent<Unity.XR.PXR.PXR_ScreenFade>().StartScreenFade(1, 0);
        yield return new WaitForSeconds(cam.GetComponent<Unity.XR.PXR.PXR_ScreenFade>().gradientTime);
        player.teleporting = false;
    }

    public void OnButtonHover()
    {
        if(!player.teleporting && !player.openingNavigation)
        {
            playerCanvas.GetComponent<AudioSource>().Stop();
            switch (gameObject.name)
            {
                case "Workbench":
                    currentClip = musicManager.getAudioClip("Dialogue", "Workbench");
                    break;

                case "VialShelf":
                    currentClip = musicManager.getAudioClip("Dialogue", "VialShelf");
                    break;

                case "SafetyGear":
                    currentClip = musicManager.getAudioClip("Dialogue", "SafetyGear");
                    break;
            }

            playClip(currentClip);
        }        
    }

    public void playClip(AudioClip clip)
    {
        playerCanvas.GetComponent<AudioSource>().clip = clip;
        playerCanvas.GetComponent<AudioSource>().Play();
    }
}
