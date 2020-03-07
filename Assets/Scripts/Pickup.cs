using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public Sprite firewoodSprite;

    public Animator anim;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    // Item can be added to the inventory in this slot
                    inventory.isFull[i] = true;
                    inventory.slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                    inventory.slots[i].transform.GetChild(0).GetComponent<Image>().sprite = firewoodSprite;
                    anim.enabled = true;
                    break;
                }
            }
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
