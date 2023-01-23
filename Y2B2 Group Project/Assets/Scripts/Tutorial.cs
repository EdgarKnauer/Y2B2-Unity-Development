using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private SpriteRenderer leftSpriteRenderer;
    [SerializeField] private SpriteRenderer rightSpriteRenderer;
    [SerializeField] private Sprite[] imagesLeftControllers;
    [SerializeField] private Sprite[] imagesRightControllers;

    [SerializeField] private GameObject prologue;
    [SerializeField] private GameObject objective1;
    [SerializeField] private GameObject objective2;
    [SerializeField] private GameObject objective3;
    [SerializeField] private GameObject objective4;
    [SerializeField] private GameObject epilogue;

    [SerializeField] private GameObject button;
    [SerializeField] private GameObject tutorialBuis;

    [SerializeField] private AudioSource goedGedaan;
    [SerializeField] private AudioSource voordatWeBeginnen;
    [SerializeField] private AudioSource allereerstAEnB;
    [SerializeField] private AudioSource gripKnop;
    [SerializeField] private AudioSource triggerKnop;
    [SerializeField] private AudioSource eindeTutorial;

    // Start is called before the first frame update
    void Start()
    {
        ChangeLeftSprite(0);
        ChangeRightSprite(0);

        //audio.PlayOneShot(voordatWeBeginnen);
        //Destroy(prologue, voordatWeBeginnen.length);
    }

    // Update is called once per frame
    void Update()
    {
        if (!prologue) objective1.SetActive(true);

        if (objective1.activeSelf)
        {
            ChangeLeftSprite(1);
            ChangeRightSprite(1);

            if (Input.GetButtonDown("primaryButton"))
            {
                objective2.SetActive(true);
                Destroy(objective1);
            }
        }
        else if (objective2.activeSelf && !objective1)
        {
            ChangeLeftSprite(2);
            ChangeRightSprite(2);  

            if (Input.GetButtonDown("secondaryButton"))
            {
                goedGedaan.Play(0);

                objective3.SetActive(true);
                
               
            }
        }
        else if (objective3.activeSelf)
        {
            ChangeRightSprite(3);

            if (tutorialBuis.tag == "TutorialDone")
            {
                goedGedaan.Play(0);

                ChangeRightSprite(4);
            }
        }
        else if (objective4.activeSelf)
        {
            if (button.tag == "Triggered")
            {
                button.SetActive(false);
                //Finish tutorial
                //Object.Destroy(this.gameObject)
            }

        }
    }

    void ChangeLeftSprite(int number)
    {
        leftSpriteRenderer.sprite = imagesLeftControllers[number];
    }

    void ChangeRightSprite(int number)
    {
        rightSpriteRenderer.sprite = imagesRightControllers[number];
    }
   
    void PressAAndB()
    {

    }
}
