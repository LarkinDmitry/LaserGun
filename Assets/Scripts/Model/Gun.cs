using System;
using UnityEngine;

class Gun : MonoBehaviour
{
    public GameObject gunBase;
    public GameObject gunBarrel;

    private Transform laserBase;
    private Transform laserBarrel;
    private Laser myLaser;

    public event Action<float> changedLaserPower;
    public event Action<float> changedLaserRange;

    private void Start()
    {
        laserBase = gunBase.GetComponent<Transform>();
        laserBarrel = gunBarrel.GetComponent<Transform>();
        myLaser = laserBarrel.GetComponent<Laser>();
    }

    public void Rotate(Vector3 rotate)
    {
        laserBase.Rotate(new Vector3(0, rotate.x, 0));
        laserBarrel.Rotate(new Vector3(rotate.y, 0, 0));
    }

    public void SetLaserPower(float value)
    {
        myLaser.SetLaserPower(value);
        changedLaserPower?.Invoke(myLaser.GetLaserPower());
    }

    public void SetLaserRange(float value)
    {
        myLaser.SetLaserRange(value);
        changedLaserRange?.Invoke(myLaser.GetLaserRange());
    }
}
