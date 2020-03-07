using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;

    public int HasItem() // Returns the index of last slot with item in OR returns -1 if no items in inventory
    {
        for (int i = slots.Length - 1; i >= 0; i--)
        {
            if (isFull[i] == true)
            {
                // This slot has item (return the index)
                return i;
            }
        }
        return -1;
    }

    public void UseItem(int slotIndex)
    {
        slots[slotIndex].transform.GetChild(0).GetComponent<Image>().enabled = false;
        isFull[slotIndex] = false;
    }
}
