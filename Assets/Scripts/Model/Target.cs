using UnityEngine;

class Target : MonoBehaviour
{
    // Variable is "public" to edit values from inspector window
    [Range(0, 10)] public float absorption = 1f;

    public float GetAbsorption() => absorption;
}
