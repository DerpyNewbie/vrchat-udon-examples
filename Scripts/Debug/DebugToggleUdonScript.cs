using UnityEngine;
using UdonSharp;
using VRC.Udon;

public class DebugToggleUdonScript : UdonSharpBehaviour
{
    public UdonBehaviour udonToToggle;

    public override void Interact()
    {
        if (udonToToggle != null)
        {
            udonToToggle.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "Toggle");
        }
    }
}
