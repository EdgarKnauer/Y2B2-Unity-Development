using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private XRNode leftController;
    [SerializeField] private XRNode rightController;

    public bool leftPrimaryPressed;
    public bool rightPrimaryPressed;
    public bool leftSecondaryPressed;
    public bool rightSecondaryPressed;

    [SerializeField] private SpriteRenderer leftSpriteRenderer;
    [SerializeField] private SpriteRenderer rightSpriteRenderer;
    [SerializeField] private Sprite[] imagesLeftControllers;
    [SerializeField] private Sprite[] imagesRightControllers;

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

        StartCoroutine(Introduction());
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice leftDevice = InputDevices.GetDeviceAtXRNode(leftController);
        InputDevice rightDevice = InputDevices.GetDeviceAtXRNode(rightController);

        leftDevice.TryGetFeatureValue(CommonUsages.primaryButton, out leftPrimaryPressed);
        rightDevice.TryGetFeatureValue(CommonUsages.primaryButton, out rightPrimaryPressed);
        leftDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out leftSecondaryPressed);
        rightDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out rightSecondaryPressed);
    }

    void ChangeLeftSprite(int number)
    {
        leftSpriteRenderer.sprite = imagesLeftControllers[number];
    }

    void ChangeRightSprite(int number)
    {
        rightSpriteRenderer.sprite = imagesRightControllers[number];
    }

    IEnumerator Introduction()
    {
        voordatWeBeginnen.Play();
        yield return new WaitWhile(() => voordatWeBeginnen.isPlaying);
        StartCoroutine(AAndB());
    }

    IEnumerator AAndB()
    {
        ChangeLeftSprite(1);
        ChangeRightSprite(1);

        allereerstAEnB.Play();
        yield return new WaitWhile(() => allereerstAEnB.isPlaying);
        while (!rightPrimaryPressed && !leftPrimaryPressed)
            yield return null;
        ChangeLeftSprite(2);
        ChangeLeftSprite(2);
        while (!rightSecondaryPressed && !leftSecondaryPressed)
            yield return null;
        goedGedaan.Play();
        yield return new WaitWhile(() => goedGedaan.isPlaying);

        StartCoroutine(GripKnop());
    }

    IEnumerator GripKnop()
    {
        ChangeRightSprite(3);

        gripKnop.Play();
        yield return new WaitWhile(() => gripKnop.isPlaying);
        tutorialBuis.SetActive(true);
        while (tutorialBuis.tag != "TutorialDone")
            yield return null;
        goedGedaan.Play();
        yield return new WaitWhile(() => goedGedaan.isPlaying);

        tutorialBuis.SetActive(false);
        StartCoroutine(TriggerKnop());
    }

    IEnumerator TriggerKnop()
    {
        ChangeRightSprite(4);

        triggerKnop.Play();
        yield return new WaitWhile(() => triggerKnop.isPlaying);
        ChangeRightSprite(5);
        button.SetActive(true);
        while (button.tag != "Triggered")
            yield return null;
        goedGedaan.Play();
        yield return new WaitWhile(() => goedGedaan.isPlaying);

        button.SetActive(false);
        StartCoroutine(Epilogue());
    }

    IEnumerator Epilogue()
    {
        eindeTutorial.Play();
        yield return new WaitWhile(() => eindeTutorial.isPlaying);

        Destroy(this);
    }
}
