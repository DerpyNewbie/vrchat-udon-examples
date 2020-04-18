using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

public class GlobalUdon : UdonSharpBehaviour
{

    // Player Mod Variables
    public float runSpeed = 4;
    public float walkSpeed = 3;
    public float jumpImpulse = 3;

    private void Start()
    {
        VRCPlayerApi player = Networking.LocalPlayer;

        if (player == null)
        {
            return;
        }

        player.SetWalkSpeed(walkSpeed);
        player.SetRunSpeed(runSpeed);
        player.SetJumpImpulse(jumpImpulse);

        // Just for test
        player.SetPlayerTag("test", "hello_world");
    }

    public override void OnPlayerJoined(VRCPlayerApi player)
    {
        Debug.Log($"Player has joined: {player.displayName}, isMaster: {player.isMaster}, isLocal: {player.isLocal}");
    }
}
