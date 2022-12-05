using UnityEngine;

public class InteractableLocker : Locker, IInteractable
{
    [SerializeField] protected string hash;
    
    public void Interact(string hash)
    {
        if (this.hash == hash)
        {
            if (IsUnlocked)
            {
                base.Lock();
            }
            else
            {
                base.Unlock();
            }
        }
    }
}