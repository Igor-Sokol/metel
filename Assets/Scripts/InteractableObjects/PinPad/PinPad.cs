using Extensions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PinPad : MonoBehaviour
{
    private char[] _inputPassword;

    [SerializeField] private string password;
    [FormerlySerializedAs("_buttons")] [SerializeField] private PinPadButton[] buttons;
    [SerializeField] private UnityEvent onInputCorrected;
    [SerializeField] private UnityEvent onInputFailed;

    private void Awake()
    {
        _inputPassword = new char[password.Length];
    }

    public void Reset()
    {
        for (int i = 0; i < _inputPassword.Length; i++)
        {
            _inputPassword[i] = '\0';
        }

        foreach (var button in buttons)
        {
            button.Reset();
        }
    }

    public void Enter()
    {
        if (password == _inputPassword.GetString())
        {
            onInputCorrected?.Invoke();
        }
        else
        {
            onInputFailed?.Invoke();
        }
        
        Reset();
    }

    public bool TryInput(char symbol)
    {
        for (int i = 0; i < _inputPassword.Length; i++)
        {
            if (_inputPassword[i] == 0)
            {
                _inputPassword[i] = symbol;
                return true;
            }
        }

        return false;
    }
}
