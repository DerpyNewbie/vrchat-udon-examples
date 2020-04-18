
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

public class DebugFloatTagSetter : UdonSharpBehaviour
{

    [Tooltip("0 = SET, 1 = ADD, 2 = SUBTRACT, 3 = MULTIPLY, 4 = DIVIDE")]
    public int operation = 0;
    public float value = 101F;
    public string tagName = "example_float";

    private int Operation_NONE = -1;
    private int Operation_SET = 0;
    private int Operation_ADD = 1;
    private int Operation_SUBTRACT = 2;
    private int Operation_MULTIPLY = 3;
    private int Operation_DIVIDE = 4;

    public override void Interact()
    {
        Operation();
    }

    public void Operation()
    {
        VRCPlayerApi player = Networking.LocalPlayer;

        float currValue = float.Parse(player.GetPlayerTag(tagName));

        if (operation == Operation_NONE)
        {
            return;
        }
        else if (operation == Operation_SET)
        {
            player.SetPlayerTag(tagName, $"{value}");
        }
        else if (operation == Operation_ADD)
        {
            player.SetPlayerTag(tagName, $"{currValue + value}");
        }
        else if (operation == Operation_SUBTRACT)
        {
            player.SetPlayerTag(tagName, $"{currValue - value}");
        }
        else if (operation == Operation_MULTIPLY)
        {
            player.SetPlayerTag(tagName, $"{currValue * value}");
        }
        else if (operation == Operation_DIVIDE)
        {
            player.SetPlayerTag(tagName, $"{currValue / value}");
        }
        else
        {
            Debug.LogWarning($"DebugFloatTagSetter: Invalid operation {operation} on {gameObject.name}.");
        }
    }
}
