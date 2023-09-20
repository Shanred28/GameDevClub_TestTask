using TMPro;
using UnityEngine;

public class UIBulletAmmo : MonoBehaviour
{
    [SerializeField] private TMP_Text m_Text;
    [SerializeField] private PlayerInventory m_PlayerInventory;

    private void Update()
    {
        m_Text.text = m_PlayerInventory.BulletAmmo.ToString();
    }
}
