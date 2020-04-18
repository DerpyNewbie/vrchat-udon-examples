
using UdonSharp;
using UnityEngine;
using UnityEngine.Animations;
using VRC.SDKBase;
using VRC.Udon;

public class DerpyGun : UdonSharpBehaviour
{
    public ParticleSystem particle;
    ParticleSystem.EmissionModule emission;

    public AimConstraint secondaryHoldFollower;
    public ParentConstraint secondaryHoldIdle;

    void Start()
    {
        Debug.Log($"DerpyGun: Spawned DerpyGun {gameObject.name}.");

        particle.Play();
        emission = particle.emission;

        Shoot(false);
        SecondaryHoldStateChange(false);
    }

    // Trigger Events

    public void OnGunTriggerDown()
    {
        Shoot(true);
    }

    public void OnGunTriggerUp()
    {
        Shoot(false);
    }

    // Secondary Hold Events

    public void OnSecondaryHoldPickup()
    {
        SecondaryHoldStateChange(true);
    }

    public void OnSecondaryHoldDrop()
    {
        SecondaryHoldStateChange(false);
    }

    // Logics

    private void Shoot(bool isShooting)
    {
        Debug.Log($"DerpyGun: Shooting {isShooting}.");
        emission.enabled = isShooting;
    }

    private void SecondaryHoldStateChange(bool isActive)
    {
        Debug.Log($"DerpyGun: HoldStateChange {isActive}.");
        secondaryHoldFollower.constraintActive = isActive;
        secondaryHoldIdle.constraintActive = !isActive;
    }

}
