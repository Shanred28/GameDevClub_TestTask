
using System;

[Serializable]
public class InventorySlot
{
    public Item Item;
    public int Amount;
    public ItemType Type;
    public int id;

    public InventorySlot(Item item, int amount, ItemType type, int id)
    {
        Item = item;
        Amount = amount;
        Type = type;
        this.id = id;
    }
}
