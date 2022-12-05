using UnityEngine;

public class OpenCloseObject : MonoBehaviour
{
    private bool _isOpen;
    private bool _inProcess;
    private float _progress;
    private float _timer;
    
    private Vector3 _closePosition;
    private Vector3 _openPosition;
    private Quaternion _closeRotation;
    private Quaternion _openRotation;
    
    [SerializeField] private Vector3 openPositionOffset;
    [SerializeField] private Vector3 openRotationOffset;
    [SerializeField] private float time;

    public bool IsOpen => _isOpen;

    private void Start()
    {
        _closePosition = transform.localPosition;
        _openPosition = transform.localPosition + openPositionOffset;
        
        _closeRotation = transform.localRotation;
        _openRotation = Quaternion.Euler(transform.localRotation.eulerAngles + openRotationOffset);
    }

    public void Open()
    {
        ChangeState(true);
    }

    public void Close()
    {
        ChangeState(false);
    }
    
    protected void ChangeState()
    {
        ChangeState(!IsOpen);
    }
    
    protected void ChangeState(bool state)
    {
        _isOpen = state;
        _inProcess = true;
    }
    
    private void Update()
    {
        if (!_inProcess) return;

        _timer += Time.deltaTime * (IsOpen ? 1f : -1f);
        _progress = _timer / time;
        
        transform.localPosition = Vector3.Lerp(_closePosition, _openPosition, _progress);
        transform.localRotation = Quaternion.Lerp(_closeRotation, _openRotation, _progress);

        if ((_progress <= 0.005 && !IsOpen) || (_progress >= 0.995 && IsOpen)) _inProcess = false;
    }
}
