using UnityEngine;

public class UIPointerClick : MonoBehaviour
{
    [SerializeField] private UIInventory target;
    private bool isClicked = false;

    public void Click()
    {
        if (!isClicked)
        {
            target.gameObject.SetActive(true); 
            isClicked = true;

            return;
        }

        target.gameObject.SetActive(false);
        isClicked = false;
    }
}
