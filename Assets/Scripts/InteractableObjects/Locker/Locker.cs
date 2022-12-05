using UnityEngine;
using UnityEngine.Events;

public class Locker : MonoBehaviour
{
    [SerializeField] protected UnityEvent onStateChanged;
    [SerializeField] protected UnityEvent onUnlocked;
    [SerializeField] protected UnityEvent onLocked;
    
    public bool IsUnlocked { get; protected set; }

    public void Unlock()
    {
        Switch(true);
    }
    
    public void Lock()
    {
        Switch(false);
    }

    private void Switch(bool state)
    {
        IsUnlocked = state;
        
        if (state)
        {
            onUnlocked?.Invoke();
        }
        else
        {
            onLocked?.Invoke();
        }
        
        onStateChanged?.Invoke();
    }
}
