using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    [Serializable]
    private class DataInventory
    {
        public Item Item;
        public int Amount;
        public ItemType Type;
        public int id;
    }


    public const string FILENAME = "completion.dat";

    [HideInInspector]public UnityEvent eventChangeInventory;
    private List<InventorySlot>  items = new List<InventorySlot>();
    private DataInventory[] invSlot;
    private int bulletAmmo;
    public int BulletAmmo => bulletAmmo;

/*    private void Awake()
    {
        Saver<DataInventory[]>.TryLoad(FILENAME, ref invSlot);
        foreach (DataInventory slot in invSlot)
        {
            InventorySlot loadSlot = new InventorySlot(slot.Item, slot.Amount, slot.Type, slot.id);
            items.Add(loadSlot);
        }
    }*/


    public void AddItem(Item item)
    { 
        foreach (var slot in items) 
        {
            if (slot.Item.Type == item.Type)
            {
                slot.Amount += item.amountItem;
                bulletAmmo = slot.Amount;
                eventChangeInventory?.Invoke();
                return;
            }             
        }

        InventorySlot newSlot = new InventorySlot(item, item.amountItem, item.Type, items.Count);
        if(newSlot.Type == ItemType.AmmoBullet)
            bulletAmmo = newSlot.Amount;
        items.Add(newSlot);
        
        eventChangeInventory?.Invoke();
    }

    public int GetAmount(int i) => i < items.Count ? items[i].Amount : 0;

    public int GetSize() => items.Count;

    public Item GetItem(int i) => i < items.Count ? items[i].Item : null;

    public bool DrawBullet()
    {

        foreach (var slot in items)
        {
            if (slot.Type == ItemType.AmmoBullet)
            {
                slot.Amount -= 1;
                bulletAmmo = slot.Amount;
                eventChangeInventory?.Invoke();
                if (slot.Amount <= 0)
                    RemoveItem(slot);
                
                return true;
            }

            
        }
        return false;        
    }

    public void RemoveItem(InventorySlot inventorySlot)
    {
        for (int i = 0; i < items.Count; i++) 
        {
            if (items[i] == inventorySlot)
             
                items.RemoveAt(i); 
        }
        eventChangeInventory?.Invoke();
    }

    public void RemoveItem(int id)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].Type == ItemType.AmmoBullet)
                bulletAmmo = 0;

            if (items[i].id == id)
                items.RemoveAt(i);
        }
        for (int i = 0; i < items.Count; i++)
        {
            items[i].id = i;
        }
        eventChangeInventory?.Invoke();
    }

    public void Save()
    {

        DataInventory[] invSlot = new DataInventory[items.Count];
        for (int i = 0; i < items.Count; i++)
        {
            invSlot[i].Type = items[i].Type;
            invSlot[i].id = items[i].id;
        }

        Saver<DataInventory[]>.Save(FILENAME, invSlot);
    }
}
