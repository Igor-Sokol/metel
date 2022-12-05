using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private Item _item;

    [SerializeField] private Image itemImage;
    [SerializeField] private Image focusImage;

    public bool IsFocused => focusImage.enabled;
    public bool IsEmpty => _item == null;
    public Item Item => _item;

    public void Focus()
    {
        focusImage.enabled = true;
    }

    public void UnFocus()
    {
        focusImage.enabled = false;
    }
    
    public bool TrySetItem(Item item)
    {
        if (_item == null)
        {
            _item = item;
            itemImage.sprite = item.ItemImage;
            itemImage.enabled = true;
            return true;
        }

        return false;
    }

    public Item RemoveItem()
    {
        var temp = _item;
        _item = null;
        itemImage.enabled = false;
        return temp;
    }
}
