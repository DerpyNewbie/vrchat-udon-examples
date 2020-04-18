using UdonSharp;
using UnityEngine;

public class UdonBox : UdonSharpBehaviour
{
    [SerializeField]
    private float multiplier = 5F;

    private void FixedUpdate()
    {
        transform.SetPositionAndRotation(transform.position,
            Quaternion.AngleAxis(Time.deltaTime * multiplier, Vector3.up));
    }
}
