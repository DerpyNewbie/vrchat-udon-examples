
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class DerpyHitDetector : UdonSharpBehaviour
{
    public UdonBehaviour eventReciever = null;
    public string eventName = null;

    private VRCPlayerApi player = null;

    private void Start()
    {
        player = Networking.LocalPlayer;
        if (player == null)
            Destroy(this);
    }

    private void Update()
    {
        VRCPlayerApi.TrackingData data = player.GetTrackingData(VRCPlayerApi.TrackingDataType.Head);
        gameObject.transform.SetPositionAndRotation(data.position, data.rotation);
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log($"HitDetector: Particle has collided with {player.displayName}!");

        if (eventReciever != null && !string.IsNullOrEmpty(eventName))
        {
            Debug.Log("HitDetector: Sending event to reciever.");
            eventReciever.SendCustomEvent(eventName);
        }
    }
}
