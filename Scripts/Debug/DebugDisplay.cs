
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class CombatDebugDisplay : UdonSharpBehaviour
{
    public Text PlayerInfoText = null;

    private void Start()
    {
        if (Networking.LocalPlayer == null)
        {
            Debug.LogWarning("DebugDisplay: LocalPlayer is null. Destroying self...");
            Destroy(this);
        }
    }

    private void FixedUpdate()
    {
        VRCPlayerApi p = Networking.LocalPlayer;

        PlayerInfoText.text =
            $"DisplayName: {p.displayName}\n" +
            $"PlayerId: {p.playerId}\n" +
            $"Position: {p.GetPosition()}\n" +
            $"CurHitpoint: {p.GetPlayerTag("combat_hp")}\n" +
            $"MaxHitpoint: {p.GetPlayerTag("combat_max_hp")}\n" +
            $"isGrounded: {p.IsPlayerGrounded()}\n" +
            $"isLocal: {p.isLocal}\n" +
            $"isMaster: {p.isMaster}\n" +
            $"PlayerTestTagValue: {p.GetPlayerTag("test")}\n" +
            $"RespawnTimer: {p.GetPlayerTag("combat_respawn_timer")}\n" +
            $"Id1: {(VRCPlayerApi.GetPlayerById(1) == null ? null : VRCPlayerApi.GetPlayerById(1).displayName)}";
    }
}
