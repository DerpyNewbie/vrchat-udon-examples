
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Teleporter : UdonSharpBehaviour
{
    public Transform teleportPos = null;

    public override void Interact()
    {
        Networking.LocalPlayer.TeleportTo(teleportPos.position, teleportPos.rotation);
    }
}
