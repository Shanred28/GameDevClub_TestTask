using System;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private List<UISlot> slots = new List<UISlot>();

    [SerializeField] private PlayerInventory inventory;
     private int index;

    private void Start()
    {
        inventory.eventChangeInventory.AddListener(UpdateInventory);
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].id = i;
        }
        UpdateInventory();
    }

    private void OnDestroy()
    {
        inventory.eventChangeInventory.RemoveListener(UpdateInventory);
    }


    public void UpdateInventory()
    {
        for (int i = 0; i < inventory.GetSize(); i++)
        {
            //slots[i].id = index;
            slots[i].gameObject.SetActive(true);
            slots[i].icon.color = new Color(1, 1, 1, 1);

            slots[i].icon.sprite = inventory.GetItem(i).icon;
            slots[i].textAmount.text = inventory.GetAmount(i) > 1 ? inventory.GetAmount(i).ToString() : " ";
            index++;
        }

        for (int i = inventory.GetSize(); i < slots.Count; i++)
        {
            slots[i].gameObject.SetActive(false);
        }
    }

    public void RemoveInventorySlot(int id)
    {
        for (int i = 0; i < inventory.GetSize(); i++)
        {
            if (slots[i].id == id)
               inventory.RemoveItem(i);
        }
            
    }
}
