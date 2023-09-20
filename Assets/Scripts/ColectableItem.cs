using UnityEngine;

public class ColectableItem : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private int amount = 1;
    [SerializeField] private SpriteRenderer sprite;

    private void Start()
    {
        amount = item.amountItem;
        sprite.sprite = item.icon;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.root.TryGetComponent<PlayerInventory>(out var inventory))
        {
            inventory.AddItem(item);
            Destroy(gameObject);
        }
    }
}
