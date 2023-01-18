using System.Collections;
using UnityEngine;

public class ButtonFunctionality : MonoBehaviour
{
    [SerializeField] private PlayerController PC;
    [SerializeField] private NPCBehaviour NPC;
    [SerializeField] private MusicManager MM;
    [SerializeField] private GameManager GM;
    private AudioClip currentClip;

    private bool onlyOneObj;

    private void Awake()
    {
        PC = FindObjectOfType<PlayerController>();
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
        bool check = CheckIfOnlyOneObjectHeld();
        if (check)
        {
            if (PC.currentlyGrabbedObj != null)
            {
                InteractableObject grabbedObj = PC.currentlyGrabbedObj.GetComponent<InteractableObject>();
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

        else
        {
            //Switch clip to, "You are holding to many objects"
            currentClip = MM.getAudioClip("Dialogue", "CurrentObjectiveTest");
            playClip(currentClip);
        }        
    }

    private bool CheckIfOnlyOneObjectHeld()
    {
        if(PC.grabbedObjLeftHand != null && PC.grabbedObjRightHand != null)
        {
            onlyOneObj = false;
        }

        else if(PC.grabbedObjLeftHand != null && PC.grabbedObjRightHand == null)
        {
            onlyOneObj = true;
            PC.currentlyGrabbedObj = PC.grabbedObjLeftHand;
        }

        else if (PC.grabbedObjLeftHand == null && PC.grabbedObjRightHand != null)
        {
            onlyOneObj = true;
            PC.currentlyGrabbedObj = PC.grabbedObjRightHand;
        }

        else if (PC.grabbedObjLeftHand == null && PC.grabbedObjRightHand == null)
        {
            onlyOneObj = true;
            PC.currentlyGrabbedObj = null;
        }

        else { }

        return onlyOneObj;
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