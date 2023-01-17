using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    public Canvas CanvasNPC;
    [SerializeField] private AudioSource AudioSourceNPC;
    [SerializeField] private MusicManager MM;

    private AudioClip GreetingClip;
    private AudioClip FarewellClip;

    private void Start()
    {
        CanvasNPC.gameObject.SetActive(false);
        GreetingClip = MM.getAudioClip("Dialogue", "Greetings");
        FarewellClip = MM.getAudioClip("Dialogue", "Farewell");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            AudioSourceNPC.clip = GreetingClip;
            AudioSourceNPC.Play();
            StartCoroutine(Greetings(GreetingClip));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            CanvasNPC.gameObject.SetActive(false);
            AudioSourceNPC.clip = FarewellClip;
            AudioSourceNPC.Play();
        }        
    }

    private IEnumerator Greetings(AudioClip clip)
    {
        new WaitForSeconds(clip.length);
        CanvasNPC.gameObject.SetActive(true);
        yield return null;
    }
}
