using UnityEngine;

public class Inventory : MonoBehaviour
{
    private InventorySlot _currentSlot;
    private InventorySlot[] _slots;

    [SerializeField] private Transform uiContainer;
    [SerializeField] private InventorySlot slotPrefab;
    [SerializeField] private int slotCount;
    [SerializeField] private float throwForce;
    [SerializeField] private Transform throwPoint;

    public Item CurrentItem => _currentSlot?.Item;
    
    private void Awake()
    {
        _slots = new InventorySlot[slotCount];
        
        for (int i = 0; i < slotCount; i++)
        {
            _slots[i] = InstantiateSlot();
        }
    }

    public bool TryAddItem(Item item)
    {
        foreach (var slot in _slots)
        {
            if (slot.TrySetItem(item))
            {
                item.gameObject.SetActive(false);
                item.transform.parent = transform;
                return true;
            }
        }

        return false;
    }

    public bool TryRemoveCurrentItem(out Item item)
    {
        if (CurrentItem)
        {
            item = _currentSlot.RemoveItem();
            
            item.gameObject.SetActive(true);
            item.transform.parent = null;
            item.transform.position = throwPoint.position;
            item.Rigidbody.AddForce(throwPoint.forward * throwForce);
            
            return true;
        }

        item = null;
        return false;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            FocusItem(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            FocusItem(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            FocusItem(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            FocusItem(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            FocusItem(4);
        }
    }

    private void FocusItem(int slotIndex)
    {
        if (slotIndex >= _slots.Length || slotIndex < 0) return;
        
        _currentSlot?.UnFocus();

        _currentSlot = _slots[slotIndex];
        _currentSlot.Focus();
    }
    
    private InventorySlot InstantiateSlot()
    {
        return Instantiate(slotPrefab, uiContainer);
    }
}
