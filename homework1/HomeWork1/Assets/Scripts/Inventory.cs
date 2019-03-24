using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject itemcanvas;

    public void showItem()
    {
        itemcanvas.SetActive(true);
    }
    public void killItem()
    {
        itemcanvas.SetActive(false);
    }
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if (itemcanvas.activeSelf)
                killItem();
            else
                showItem();
        }
    }

    public Image[] itemImages = new Image[numItemSlots];
    public Item[] items = new Item[numItemSlots];
    public Item nu;
    public const int numItemSlots = 12;
    int itemCount = 0;

    public int FindItem(Item itemToFind)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == itemToFind)
            {
                return i;
            }
        }
        return -1;
    }

    public bool AddItem(Item itemToAdd)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = itemToAdd;
                itemImages[i].sprite = itemToAdd.sprite;
                itemImages[i].enabled = true;
                return true;
            }
        }
        return false;
    }
    public bool RemoveItem(Item itemToRemove)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == itemToRemove)
            {
                items[i] = null;
                itemImages[i].sprite = nu.sprite;
                return true;
            }
        }
        return false;
    }
}
