using System.Collections.Generic;
using UnityEngine;

class Laser : MonoBehaviour
{
    public GameObject LinePrefab;

    private LineRenderer laserLine;

    // list of start, reflection and finish points
    private List<Vector3> laserBreakpoints = new List<Vector3>();

    // default laser range = 0
    private float laserRange;

    // default max laser range = 100
    private float maxLaserRange = 100;

    // default laser power = 0
    private float laserPower;

    // default laser power = 100
    private float maxLaserPower = 100;

    // forward offset
    private float forwardOffset = 0.8f;

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
        Vector3 startLaserPoint = transform.position + transform.forward * forwardOffset;

        // write start point
        laserBreakpoints.Add(startLaserPoint);

        // create new ray (recursive function)
        BuildRays(startLaserPoint, transform.forward, laserRange, laserPower);

        // draw laser line
        DrawLines();
    }

    private void BuildRays(Vector3 startPosition, Vector3 direction, float laserRange, float power)
    {
        Ray ray = new Ray(startPosition, direction);

        // intersection point calculation
        bool intersect = Physics.Raycast(ray, out RaycastHit hit, laserRange);
        Vector3 hitPosition = intersect ? hit.point : startPosition + direction * laserRange;

        // add new intersect point or finish point
        laserBreakpoints.Add(hitPosition);

        // calculation remainder laser length
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
        // set breakpoints count
        laserLine.positionCount = laserBreakpoints.Count;
        // draw new laser line
        laserLine.SetPositions(laserBreakpoints.ToArray());
    }

    // check correctness of input value
    public void SetLaserRange(float range)
    {
        // range >= 0
        if (range < 0) range = 0;

        // range <= maxLaserRange
        if (range > maxLaserRange) range = maxLaserRange;

        laserRange = range;
    }

    // check correctness of input value
    public void SetLaserPower(float power)
    {
        // power >= 0
        if (power < 0) power = 0;

        // power <= maxLaserPower
        if (power > maxLaserPower) power = maxLaserPower;

        laserPower = power;
    }

    public float GetLaserRange() => laserRange;

    public float GetLaserPower() => laserPower;
}
