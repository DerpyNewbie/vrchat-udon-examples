
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;

public class PlayerStopper : UdonSharpBehaviour
{
    [UdonSynced]
    public bool enableTeleport = true;
    public string displayName = "ÉLÉìÉçÉN";
    public Transform spawnPos = null;
    public bool useInputField = false;
    public InputField inputField = null;

    private bool isLocalPlayer = false;

    private void Start()
    {
        if (Networking.LocalPlayer == null)
        {
            isLocalPlayer = false;
            return;
        }

        Refresh();
    }

    private void Update()
    {
        if (isLocalPlayer && enableTeleport)
        {
            Networking.LocalPlayer.TeleportTo(
                spawnPos.position,
                spawnPos.rotation,
                VRC_SceneDescriptor.SpawnOrientation.AlignRoomWithSpawnPoint,
                false);
        }
    }

    public override void Interact()
    {
        SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.Owner, "Toggle");
        Refresh();
    }

    public void Toggle()
    {
        enableTeleport = !enableTeleport;
        Debug.Log($"PlayerStopper: Toggled for {displayName}, currently {enableTeleport}!");
    }

    public void Refresh()
    {
        if (useInputField)
        {
            displayName = inputField.text;
        }

        if (Networking.LocalPlayer.displayName.ToLower() == displayName.ToLower())
        {
            Debug.Log($"PlayerStopper: LocalPlayer is {displayName}");
            isLocalPlayer = true;
        }
        else
        {
            Debug.Log($"PlayerStopper: LocalPlayer is NOT {displayName}");
            isLocalPlayer = false;
        }
    }
}
