using UnityEngine;

public class Target : MonoBehaviour
{
    // public for edit from inspector window
    [Range(0, 10)] public float absorption = 2f;

    public float GetAbsorption() => absorption;
}
