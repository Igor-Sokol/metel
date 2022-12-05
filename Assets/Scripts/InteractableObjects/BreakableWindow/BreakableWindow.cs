using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BreakableWindow : MonoBehaviour
{
    private bool _isBroke;
    
    [SerializeField] private string hash;
    [SerializeField] private GameObject glass;
    [SerializeField] private GameObject splintersContainer;

    public void ClearSplinters()
    {
        if (_isBroke)
        {
            splintersContainer.SetActive(false);
        }
    }
    
    private void Break()
    {
        glass.SetActive(false);
        splintersContainer.SetActive(true);
        _isBroke = true;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Item item))
        {
            if (item.Hash == hash)
            {
                Break();
            }
        }
    }
}
