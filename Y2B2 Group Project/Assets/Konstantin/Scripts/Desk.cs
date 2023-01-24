using UnityEngine;
using System.Collections.Generic;


public class Desk : MonoBehaviour
{
    public List<GameObject> items;
    public BoxCollider boxCollider;
    public bool allItemsOn = false;
    public BoxCollider playerGotEquipment;
    public bool allItemsEquiped = false;



    void Update()
    {
        bool ReadyForNextTask = true;
        bool ItemEquiped = false;
        foreach (GameObject item in items)
        {
            if (boxCollider.bounds.Contains(item.transform.position))
            {
                ReadyForNextTask = false;
                break;
            }
        }
        allItemsOn = ReadyForNextTask;

        foreach (GameObject item in items)
        {

            if (playerGotEquipment.bounds.Contains(item.transform.position))
            {
                item.SetActive(false);
            }

            if (items.TrueForAll(item => item.activeSelf == false))
            {
                ItemEquiped = true;
            }
        }

        allItemsEquiped = ItemEquiped;


        if (allItemsOn == true && allItemsEquiped == true)
        {

        }
    }
}