using UnityEngine;

public class InteractableOpenCloseObject : OpenCloseObject, IInteractable
{
    [SerializeField, Header("Can be null")] private Locker locker;
    
    public void Interact(string hash)
    {
        if (!locker?.IsUnlocked ?? false) return;
        
        base.ChangeState();
    }
}