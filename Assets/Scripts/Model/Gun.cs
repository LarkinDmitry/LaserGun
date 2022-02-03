using System;
using UnityEngine;

class Gun : MonoBehaviour
{
    public GameObject gunBase;
    public GameObject gunBarrel;

    private Transform laserBase;
    private Transform laserBarrel;
    private Laser myLaser;

    // events
    public event Action<float> changedLaserPower;
    public event Action<float> changedLaserRange;

    private void Start()
    {
        // get link
        laserBase = gunBase.GetComponent<Transform>();
        laserBarrel = gunBarrel.GetComponent<Transform>();
        myLaser = laserBarrel.GetComponent<Laser>();

        // set defolt value
        SetLaserRange(20f);
        SetLaserPower(10f);
        Rotate(Vector3.zero);
    }

    public void Rotate(Vector3 rotate)
    {
        //rotate base
        laserBase.Rotate(new Vector3(0, rotate.x, 0));
        //rotate barrel
        laserBarrel.Rotate(new Vector3(rotate.y, 0, 0));
    }

    public void SetLaserPower(float value)
    {
        // set and update laser power
        myLaser.SetLaserPower(value);
        changedLaserPower?.Invoke(myLaser.GetLaserPower());
    }

    public void SetLaserRange(float value)
    {
        // set and update laser range
        myLaser.SetLaserRange(value);
        changedLaserRange?.Invoke(myLaser.GetLaserRange());
    }
}
