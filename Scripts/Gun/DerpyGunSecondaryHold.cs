
using UdonSharp;
using VRC.Udon;

public class DerpyGunSecondaryHold : UdonSharpBehaviour
{
    public UdonBehaviour derpyGun = null;

    public override void OnPickup()
    {
        derpyGun.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "OnSecondaryHoldPickup");
    }

    public override void OnDrop()
    {
        derpyGun.SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "OnSecondaryHoldDrop");
    }
}
