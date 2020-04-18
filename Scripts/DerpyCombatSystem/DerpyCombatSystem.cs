using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

public class DerpyCombatSystem : UdonSharpBehaviour
{
    public float maxHp = 100F;
    public float respawnTimer = 3F;
    public Transform respawnPos = null;

    private float currentRespawnTimer = 0F;
    private bool inDeathProcess = false;
    private Vector3 lastPosition = Vector3.zero;
    private VRCPlayerApi player = null;

    private void Start()
    {
        player = Networking.LocalPlayer;
        if (player == null)
            Destroy(this);

        currentRespawnTimer = respawnTimer;

        player.SetPlayerTag("combat_hp", $"{maxHp}");
        player.SetPlayerTag("combat_max_hp", $"{maxHp}");
    }

    private void Update()
    {
        if (!inDeathProcess)
            TickHealthStatus();
        else
            TickDeathProcess();
    }

    private void TickDeathProcess()
    {
        currentRespawnTimer = currentRespawnTimer - Time.fixedDeltaTime;

        player.TeleportTo(lastPosition, player.GetTrackingData(VRCPlayerApi.TrackingDataType.Head).rotation);

        if (currentRespawnTimer < 0F)
        {
            if (respawnPos != null)
            {
                player.TeleportTo(respawnPos.position, respawnPos.rotation);
                Debug.Log($"CombatSystem: Teleported {player.displayName} to respawn position of {respawnPos.position}.");
            }

            currentRespawnTimer = respawnTimer;

            Debug.Log($"CombatSystem: {player.displayName} is now able to move.");

            float maxHp = float.Parse(player.GetPlayerTag("combat_max_hp"));
            player.SetPlayerTag("combat_hp", $"{maxHp}");

            inDeathProcess = false;
            
        }

        player.SetPlayerTag("combat_respawn_timer", $"{currentRespawnTimer}");
    }

    private void TickHealthStatus()
    {
        float hp = float.Parse(player.GetPlayerTag("combat_hp"));

        if (hp < 0)
        {
            Debug.Log($"CombatSystem: {player.displayName} has died!");

            lastPosition = player.GetPosition();

            Debug.Log($"CombatSystem: {player.displayName} is now unable to move.");

            inDeathProcess = true;
        }
    }
}
