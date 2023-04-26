using UnityEngine;

class Target : MonoBehaviour
{
    [SerializeField][Range(0, 10)] private float absorption = 1f;
    public float GetAbsorption() => absorption;
}