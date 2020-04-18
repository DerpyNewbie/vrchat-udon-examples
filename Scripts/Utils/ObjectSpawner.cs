
using UdonSharp;
using UnityEngine;

public class ObjectSpawner : UdonSharpBehaviour
{
    public GameObject original = null;
    public Transform spawnPos = null;
    public bool activateOnSpawn = true;
    public bool spawnGlobally = true;

    public override void Interact()
    {
        if (spawnGlobally)
        {
            SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "Spawn");
        }
        else
        {
            SendCustomEvent("Spawn");
        }
    }

    public void Spawn()
    {
        GameObject spawnedObject = VRCInstantiate(original);
        spawnedObject.transform.SetPositionAndRotation(spawnPos.position, spawnPos.rotation);
        spawnedObject.SetActive(activateOnSpawn);
    }
}
