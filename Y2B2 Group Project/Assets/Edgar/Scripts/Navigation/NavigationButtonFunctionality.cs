using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationButtonFunctionality : MonoBehaviour
{
    [SerializeField] private List<Transform> navigationLocations;
    [SerializeField] private PlayerController player;

    [SerializeField] private Camera cam;

    [SerializeField] private Canvas playerCanvas;
    [SerializeField] private MusicManager musicManager;

    public AudioClip currentClip;
    


    public void OnShelfButtonClicked()
    {
        if(!player.teleporting && !player.openingNavigation)
        {
            player.teleporting = true;
            StopAllCoroutines();
            StartCoroutine(ScreenFader(navigationLocations[0]));
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

    public void OnWorktableButtonClicked()
    {
        if (!player.teleporting && !player.openingNavigation)
        {
            player.teleporting = true;
            StopAllCoroutines();
            StartCoroutine(ScreenFader(navigationLocations[2]));
        }
    }

    IEnumerator ScreenFader(Transform teleportLocation)
    {        
      //cam.GetComponent<Unity.XR.PXR.PXR_ScreenFade>().StartScreenFade(0, 1);
        yield return new WaitForSeconds(cam.GetComponent<Unity.XR.PXR.PXR_ScreenFade>().gradientTime);

        player.transform.position = teleportLocation.position;
        player.transform.rotation = teleportLocation.rotation;

      //cam.GetComponent<Unity.XR.PXR.PXR_ScreenFade>().StartScreenFade(1, 0);
        player.teleporting = false;
    }

    public void OnButtonHover()
    {
        if(!player.teleporting && !player.openingNavigation)
        {
            StopAllCoroutines();
            playerCanvas.GetComponent<AudioSource>().Stop();
            switch (gameObject.name)
            {
                case "B_Worktable":
                    currentClip = musicManager.getAudioClip("Dialogue", "QuestionTask");
                    break;

                case "B_Shelf":
                    currentClip = musicManager.getAudioClip("Dialogue", "QuestionObject");
                    break;

                case "B_SafetyEquip":
                    currentClip = musicManager.getAudioClip("Dialogue", "QuestionLooks");
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
