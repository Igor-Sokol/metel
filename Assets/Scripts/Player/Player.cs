using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Inventory inventory;
    [SerializeField] private float handDistance;

    private void Awake() //TODO
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit, handDistance))
            {
                if (hit.collider.TryGetComponent(out Item item))
                {
                    inventory.TryAddItem(item);
                }
                
                if (hit.collider.TryGetComponent(out IInteractable interactable))
                {
                    interactable.Interact(inventory.CurrentItem?.Hash);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            inventory.TryRemoveCurrentItem(out Item item);
        }
    }
}
