using UnityEngine;

interface IRotator
{
    // get command from model (via a presenter)
    void SetRotate(Vector3 rotate);
}
