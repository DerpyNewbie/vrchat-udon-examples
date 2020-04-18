
using UdonSharp;
using UnityEngine.UI;

public class Counter : UdonSharpBehaviour
{
    [UdonSynced]
    public int value;
    public Text text;

    private void Start()
    {
        UpdateValueDisplay();
    }

    public void UpdateValueDisplay()
    {
        text.text = $"{value}";
    }

    public override void OnDeserialization()
    {
        UpdateValueDisplay();
    }

    public void Increment()
    {
        value++;
        UpdateValueDisplay();
    }

    public void Subtract()
    {
        value--;
        UpdateValueDisplay();
    }

    public void Reset()
    {
        value = 0;
        UpdateValueDisplay();
    }
}
