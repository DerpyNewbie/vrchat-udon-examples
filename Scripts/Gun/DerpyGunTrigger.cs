
using UdonSharp;
using VRC.Udon;

public class DerpyGunTrigger : UdonSharpBehaviour
{
    public UdonBehaviour derpyGun = null;

    public override void OnPickupUseDown()
    {
        derpyGun.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "OnGunTriggerDown");
    }

    public override void OnPickupUseUp()
    {
        derpyGun.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "OnGunTriggerUp");
    }
}
