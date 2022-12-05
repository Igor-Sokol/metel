using UnityEngine;
using UnityEngine.Events;

public class PinPadSpecial : PinPadButton
{
    [SerializeField] private UnityEvent pressEvent;
    
    protected override void Press()
    {
        pressEvent?.Invoke();
    }

    public override void Reset()
    {
    }
}