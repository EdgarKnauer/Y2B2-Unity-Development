using System.Collections;
using UnityEngine;

public class ButtonFunctionality : MonoBehaviour
{
    [SerializeField] private CharacterController CC;
    [SerializeField] private NPCBehaviour NPC;
    [SerializeField] private MusicManager MM;
    [SerializeField] private GameManager GM;
    private AudioClip currentClip;

    private void Awake()
    {
        CC = FindObjectOfType<CharacterController>();
        NPC = FindObjectOfType<NPCBehaviour>();
        MM = FindObjectOfType<MusicManager>();
        GM = FindObjectOfType<GameManager>();
    }

    public void OnButtonHover()
    {
        StopAllCoroutines();
        NPC.GetComponent<AudioSource>().Stop();
        switch (gameObject.name)
        {
            case "Task":
                currentClip = MM.getAudioClip("Dialogue", "QuestionTask");
                break;

            case "Object":
                currentClip = MM.getAudioClip("Dialogue", "QuestionObject");
                break;

            case "Looks":
                currentClip = MM.getAudioClip("Dialogue", "QuestionLooks");
                break;

            case "Dangers":
                currentClip = MM.getAudioClip("Dialogue", "QuestionDangers");
                break;
        }

        playClip(currentClip);
    }

    public void OnButtonRelease()
    {
        if (CC.grabbedObj != null)
        {
            InteractableObject grabbedObj = CC.grabbedObj.GetComponent<InteractableObject>();
            //string gameState = GM.gameStates.ToString();

            switch (gameObject.name)
            {
                case "Task":
                    currentClip = MM.getAudioClip("Dialogue", "CurrentObjectiveTest");
                    //currentClip = GM.currentObjective;
                    break;

                case "Object":
                    currentClip = MM.getAudioClip("Dialogue", grabbedObj.dialogueObject);
                    break;

                case "Looks":
                    currentClip = MM.getAudioClip("Dialogue", grabbedObj.dialogueLooks);
                    break;

                case "Dangers":
                    currentClip = MM.getAudioClip("Dialogue", grabbedObj.dialogueDangers);
                    break;
            }

            StartCoroutine(clickPlay(currentClip));
        }

        else
        {
            if (gameObject.name == "Task")
            {
                currentClip = MM.getAudioClip("Dialogue", "CurrentObjectiveTest");
                //currentClip = GM.currentObjective;
            }
            else
            {
                currentClip = MM.getAudioClip("Dialogue", "NoObject");
            }
            playClip(currentClip);
        }
    }

    private void playClip(AudioClip clip)
    {
        NPC.GetComponent<AudioSource>().clip = clip;
        NPC.GetComponent<AudioSource>().Play();
    }

    private IEnumerator clickPlay(AudioClip clip)
    {
        playClip(clip);
        new WaitForSeconds(clip.length);
        yield return null;
    }
}