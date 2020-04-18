
using UdonSharp;

using VRC.SDKBase;
using VRC.Udon;

public class DerpyGunSecondaryHold : UdonSharpBehaviour
{
    public UdonBehaviour derpyGun = null;

    public override void OnPickup()
    {
        derpyGun.SendCustomEvent("OnSecondaryHoldPickup");
    }

    public override void OnDrop()
    {
        derpyGun.SendCustomEvent("OnSecondaryHoldDrop");
    }
}
