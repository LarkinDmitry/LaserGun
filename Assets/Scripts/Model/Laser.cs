using System.Collections.Generic;
using UnityEngine;

class Laser : MonoBehaviour
{
    // laser prefab
    public GameObject LinePrefab;

    // list of start, reflection and finish points
    private List<Vector3> laserBreakpoints = new List<Vector3>();

    // defalte laser range = 0
    private float maxLaserRange;

    // defalte laser power = 0
    private float laserPower;

    // ray renderer
    private LineRenderer laserLine;

    private void Start()
    {
        // create prefab of laser ray
        laserLine = Instantiate(LinePrefab, Vector3.zero, Quaternion.identity).GetComponent<LineRenderer>();
    }

    private void Update()
    {
        // clear ray list
        if (laserBreakpoints.Count != 0) laserBreakpoints.Clear();

        // set start point with offset
        Vector3 startLaserPoint = transform.position - transform.forward;

        // write start point
        laserBreakpoints.Add(startLaserPoint);

        // create new ray (recursive function)
        BuildRays(startLaserPoint, -transform.forward, maxLaserRange, laserPower);

        // draw laser line
        DrawLines();
    }

    private void BuildRays(Vector3 startPosition, Vector3 direction, float laserRange, float power)
    {
        RaycastHit hit;

        // create ray
        Ray ray = new Ray(startPosition, direction);

        // intersection point calculation
        bool intersect = Physics.Raycast(ray, out hit, laserRange);
        Vector3 hitPosition = intersect ? hit.point : startPosition + direction * laserRange;

        // add new intersect point or finish point
        laserBreakpoints.Add(hitPosition);

        // calculation remainder laser lenth
        float remaindLaserRange = laserRange - hit.distance;

        // calculation remainder power (in case of intersect)
        float remainderPower = power;
        if (intersect)
        {
            // checking if it is a target
            if (hit.transform.gameObject.GetComponent<Target>() != null)
            {
                // set new value
                remainderPower -= hit.transform.gameObject.GetComponent<Target>().GetAbsorption();
            }

            // if there is still laser power, create new ray
            if (remainderPower > 0)
            {
                BuildRays(hitPosition, Vector3.Reflect(direction, hit.normal), remaindLaserRange, remainderPower);
            }
        }
    }

    // draw laser line
    private void DrawLines()
    {
        // set breackpoints count
        laserLine.positionCount = laserBreakpoints.Count;
        // draw new laser line
        laserLine.SetPositions(laserBreakpoints.ToArray());
    }

    public void SetLaserRange(float range)
    {
        // chec length >= 0
        maxLaserRange = range > 0 ? range : 0;
    }

    public void SetLaserPower(float power)
    {
        // chec power >= 0
        laserPower = power > 0 ? power : 0;
    }

    public float GetLaserRange() => maxLaserRange;

    public float GetLaserPower() => laserPower;
}
