using UnityEngine;

public enum ItemType
{
    AmmoBullet,
    Other
}
[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string Name;
    public ItemType Type;
    public int amountItem;
    public Sprite icon;

}
