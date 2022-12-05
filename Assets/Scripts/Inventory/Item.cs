using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Item : MonoBehaviour
{
    private Rigidbody _rigidbody;
    
    [SerializeField] private Sprite itemImage;
    [SerializeField] private string hash;

    public Sprite ItemImage => itemImage;
    public string Hash => hash;
    public Rigidbody Rigidbody => _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }
}
