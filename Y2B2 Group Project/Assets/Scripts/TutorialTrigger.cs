using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    public void ChangeTagOfButton()
    {
        gameObject.tag = "Triggered";
    }
}
