using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private SpriteRenderer leftSpriteRenderer;
    [SerializeField] private SpriteRenderer rightSpriteRenderer;
    [SerializeField] private Sprite[] imagesLeftControllers;
    [SerializeField] private Sprite[] imagesRightControllers;

    string currentObjective;

    [SerializeField] private GameObject button;

    [SerializeField] private AudioSource goedGedaan;

    // Start is called before the first frame update
    void Start()
    {
        currentObjective = "Press A";
        ChangeLeftSprite(0);
        ChangeRightSprite(0);
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (currentObjective == "Press A")
    //    {
    //        if (Input.GetButtonDown("primaryButton"))
    //        {
    //            goedGedaan.Play(0);

    //            currentObjective = "Press B";
    //            ChangeLeftSprite(2);
    //            ChangeRightSprite(2);              
    //        }
    //    }
    //    else if (currentObjective == "Press B")
    //    {
    //        if (Input.GetButtonDown("secondaryButton"))
    //        {
    //            goedGedaan.Play(0);

    //            currentObjective = "Pick up an item";
    //            ChangeRightSprite(3);
               
    //        }
    //    }
    //    else if (currentObjective == "Pick up an item")
    //    {
    //        //If the player succesfully picked up an item
    //        //{   
    //        //    goedGedaan.Play(0);
    //        //
    //        //    currentObjective = "Point and press trigger"
    //        //    ChangeRightSprite(5);
    //        //    button.SetActive(true);    
    //        //}
    //    }
    //    else if (currentObjective == "Point and press trigger")
    //    {
    //        //If the player succesfully pointed at an object and interacted with it
    //        //button.SetActive(false);
    //        //Finish tutorial
    //        //Object.Destroy(this.gameObject)
    //    }
    //}

    void ChangeLeftSprite(int number)
    {
        leftSpriteRenderer.sprite = imagesLeftControllers[number];
    }

    void ChangeRightSprite(int number)
    {
        rightSpriteRenderer.sprite = imagesRightControllers[number];
    }
   
}
