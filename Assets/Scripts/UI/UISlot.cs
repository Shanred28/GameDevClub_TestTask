using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    public Image icon;
    public TMP_Text textAmount;
     public int id;
    [SerializeField] private UIInventory inventory;

    public void Delete()
    {
        inventory.RemoveInventorySlot(id);
    }
}
