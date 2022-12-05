using UnityEngine;

public class PinPadNumber : PinPadButton
{
    private Color _unselectedColor;
    private Material CurrentMaterial => pinPadRenderer.materials[pinPadMaterialId];

    [SerializeField] private char symbol;
    [SerializeField] private Material selectedColor;
    [SerializeField] private Renderer pinPadRenderer;
    [SerializeField] private int pinPadMaterialId;

    private void Awake()
    {
        _unselectedColor = CurrentMaterial.color;
    }

    protected override void Press()
    {
        if (PinPad.TryInput(symbol))
        {
            CurrentMaterial.color = selectedColor.color;
        }
    }

    public override void Reset()
    {
        CurrentMaterial.color = _unselectedColor;
    }
}