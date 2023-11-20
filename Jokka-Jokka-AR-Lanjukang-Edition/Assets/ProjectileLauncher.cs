using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public Transform launchPoint1, launchPoint2;
    public GameObject projectile1, projectile2;
    public float launchSpeed = 10f;

    [Header("****Trajectory Display****")]
    public LineRenderer lineRenderer;
    public int linePoints = 175;
    public float timeIntervalInPoints = 0.01f;

    void Update()
    {
        // if(lineRenderer != null)
        // {
        //     if(Input.GetMouseButton(1))
        //     {
        //         DrawTrajectory();
        //         lineRenderer.enabled = true;
        //     }
        //     else
        //         lineRenderer.enabled = false;
        // }
        if (Input.GetMouseButtonDown(0))
        {
            var _projectile = Instantiate(projectile1, launchPoint1.position, launchPoint1.rotation);
            _projectile.GetComponent<Rigidbody>().velocity = launchSpeed * launchPoint1.up;
        
        }
        else if (Input.GetMouseButtonDown(1))
        {
            var _projectile1 = Instantiate(projectile2, launchPoint2.position, launchPoint2.rotation);
            _projectile1.GetComponent<Rigidbody>().velocity = launchSpeed * launchPoint2.up;

        }
    }

    void DrawTrajectory()
    {
        Vector3 origin = launchPoint1.position;
        Vector3 startVelocity = launchSpeed * launchPoint1.up;
        lineRenderer.positionCount = linePoints;
        float time = 0;
        for (int i = 0; i < linePoints; i++)
        {
            // s = u*t + 1/2*g*t*t
            var x = (startVelocity.x * time) + (Physics.gravity.x / 2 * time * time);
            var y = (startVelocity.y * time) + (Physics.gravity.y / 2 * time * time);
            Vector3 point = new Vector3(x, y, 0);
            lineRenderer.SetPosition(i, origin + point);
            time += timeIntervalInPoints;
        }
    }
}
