using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string dialogueObject;
    public string dialogueLooks;
    public string dialogueDangers;

    public bool isGrabbed = false;
    public GameObject coupledHand;

    public string chemicalType;
    public int PHLevel;
    public bool hasBBlueInIt;
    public bool vialIsFull = false;
    public bool vialIsEmpty = false;

    [Header("Chemical Combination")]
    public bool BBLueAndH2O = false;
    public bool BBLueAndNaOH = false;
    public bool BBLueAndHCL = false;

    public void addingLiquid(string addedChemicalType)
    {
        vialIsFull = true;
        hasBBlueInIt = true;

        switch(chemicalType)
        {
            case "BromothymolBlue":
                switch (addedChemicalType)
                {
                    case "H2O": BBLueAndH2O = true; break;
                    case "NaOH": BBLueAndNaOH = true; break;
                    case "HCL": BBLueAndHCL = true; break;
                };
                break;

            case "H2O":
                BBLueAndH2O = true;
                break;
            case "NaOH":
                BBLueAndNaOH = true;
                break;
            case "HCL":
                BBLueAndHCL = true;
                break;
        }
    }

    public void removingLiquid(string removedChemicalType)
    {
        vialIsEmpty = true;
        hasBBlueInIt = false;
    }
}