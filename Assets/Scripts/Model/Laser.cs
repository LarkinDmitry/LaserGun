using System.Collections.Generic;
using UnityEngine;

class Laser : MonoBehaviour
{
    public GameObject LinePrefab;

    private LineRenderer laserLine;

    private List<Vector3> laserBreakpoints = new List<Vector3>();

    private float laserRange;

    private readonly float maxLaserRange = 100;

    private float laserPower;

    private readonly float maxLaserPower = 100;

    private readonly float forwardOffset = 0.8f;

    private void Start()
    {
        laserLine = Instantiate(LinePrefab, Vector3.zero, Quaternion.identity).GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (laserBreakpoints.Count != 0) laserBreakpoints.Clear();

        Vector3 startLaserPoint = transform.position + transform.forward * forwardOffset;

        laserBreakpoints.Add(startLaserPoint);

        BuildRays(startLaserPoint, transform.forward, laserRange, laserPower);
        DrawLines();
    }

    private void BuildRays(Vector3 startPosition, Vector3 direction, float laserRange, float power)
    {
        Ray ray = new (startPosition, direction);

        bool intersect = Physics.Raycast(ray, out RaycastHit hit, laserRange);
        Vector3 hitPosition = intersect ? hit.point : startPosition + direction * laserRange;

        laserBreakpoints.Add(hitPosition);

        float remaindLaserRange = laserRange - hit.distance;

        float remainderPower = power;
        if (intersect)
        {
            if (hit.transform.gameObject.GetComponent<Target>() != null)
            {
                remainderPower -= hit.transform.gameObject.GetComponent<Target>().GetAbsorption();
            }

            if (remainderPower > 0)
            {
                BuildRays(hitPosition, Vector3.Reflect(direction, hit.normal), remaindLaserRange, remainderPower);
            }
        }
    }

    private void DrawLines()
    {
        laserLine.positionCount = laserBreakpoints.Count;
        laserLine.SetPositions(laserBreakpoints.ToArray());
    }

    public void SetLaserRange(float range)
    {
        laserRange = Mathf.Clamp(range, 0, maxLaserRange);
    }

    public void SetLaserPower(float power)
    {
        laserPower = Mathf.Clamp(power, 0, maxLaserPower);
    }

    public float GetLaserRange() => laserRange;

    public float GetLaserPower() => laserPower;
}
