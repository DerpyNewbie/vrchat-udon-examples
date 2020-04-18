
using UdonSharp;
using UnityEngine;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;

public class ValueSetter : UdonSharpBehaviour
{
    public UdonBehaviour counter;
    // Can't use enum. so using string instead.
    [Tooltip("Operation types are: {RESET = 0, ADD = 1, SUBTRACT = 2}. defaults 0.")]
    public int operation = 0;

    private int Operation_RESET = 0;
    private int Operation_ADD = 1;
    private int Operation_SUBTRACT = 2;

    public override void Interact()
    {
        if (operation == Operation_RESET)
        {
            counter.SendCustomNetworkEvent(NetworkEventTarget.All, "Reset");
        }
        else if (operation == Operation_ADD)
        {
            counter.SendCustomNetworkEvent(NetworkEventTarget.All, "Increment");
        }
        else if (operation == Operation_SUBTRACT)
        {
            counter.SendCustomNetworkEvent(NetworkEventTarget.All, "Subtract");
        }
    }
}
