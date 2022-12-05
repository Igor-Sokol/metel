using UnityEngine;

public abstract class PinPadButton : MonoBehaviour, IInteractable
{
    [SerializeField] protected PinPad PinPad;

    protected abstract void Press();

    public abstract void Reset();
    
    public void Interact(string hash)
    {
        Press();
    }
}
