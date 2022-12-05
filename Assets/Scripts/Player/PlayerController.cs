using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController _characterController;
    private Vector3 _cameraStandPosition;
    private Vector3 _cameraSitPosition;
    private float _yVelocity;
    private bool _isSitting;

    [SerializeField] private float gravity;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float verticalRotationLimit;
    [SerializeField] private Transform cameraContainer;
    [SerializeField] private Vector3 sitCameraOffset;
    [SerializeField] private float sitSpeed;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _cameraStandPosition = cameraContainer.localPosition;
        _cameraSitPosition = _cameraStandPosition + sitCameraOffset;
    }
    
    private void Update()
    {
        Sit();
        Jump();
        _characterController.Move((Movement() + Gravity()) * Time.deltaTime);
        
        Rotate();
    }

    private void Sit()
    {
        Vector3 targetPosition = Input.GetKey(KeyCode.LeftControl) ? _cameraSitPosition : _cameraStandPosition;
        cameraContainer.localPosition = Vector3.Lerp(cameraContainer.localPosition, targetPosition, sitSpeed * Time.deltaTime);
    }
    
    private void Jump()
    {
        if (_characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _yVelocity = jumpForce;
        }
    }
    
    private Vector3 Gravity()
    {
        if (_characterController.isGrounded && _yVelocity < 0)
        {
            _yVelocity = gravity;
        }
        else
        {
            _yVelocity += gravity * Time.deltaTime;
        }
        
        return Vector3.up * _yVelocity;
    }
    
    private Vector3 Movement()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        
        Vector3 movement = new Vector3(horizontal * speed, 0, vertical * speed);

        return transform.TransformDirection(movement);
    }

    private void Rotate()
    {
        float horizontalRotation = Input.GetAxis("Mouse X");
        _characterController.transform.Rotate(Vector3.up, horizontalRotation * rotationSpeed);

        float verticalRotation = Input.GetAxis("Mouse Y");
        
        float xCameraRotation = cameraContainer.transform.rotation.eulerAngles.x;
        xCameraRotation = xCameraRotation > 180 ? (xCameraRotation - 360f) : xCameraRotation;
        
        if (xCameraRotation <= verticalRotationLimit && verticalRotation < 0
            || xCameraRotation >= -verticalRotationLimit && verticalRotation > 0)
        {
            cameraContainer.transform.Rotate(Vector3.right, -verticalRotation * rotationSpeed);
        }
    }
}
