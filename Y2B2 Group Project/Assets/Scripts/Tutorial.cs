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

    // Start is called before the first frame update
    void Start()
    {
        currentObjective = "Press A";
        ChangeLeftSprite(1);
        ChangeRightSprite(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentObjective == "Press A")
        {
            if (Input.GetButtonDown("primaryButton"))
            {
                currentObjective = "Press B";
                ChangeLeftSprite(2);
                ChangeRightSprite(2);
            }
        }
        else if (currentObjective == "Press B")
        {
            if (Input.GetButtonDown("secondaryButton"))
            {
                currentObjective = "Pick up an item";
                ChangeRightSprite(3);
            }
        }
        else if (currentObjective == "Pick up an item")
        {
            //If the player succesfully picked up an item
            //{
            //    currentObjective = "Point and press trigger"
            //    ChangeRightSprite(5);
            //}
        }
        else if (currentObjective == "Point and press trigger")
        {
            //If the player succesfully pointed at an object and interacted with it
            //Finish tutorial 
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
}
