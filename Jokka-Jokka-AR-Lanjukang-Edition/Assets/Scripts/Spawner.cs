using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemies;

    public GameObject[] UI;

    public Transform launchPoint1, launchPoint2;
    public GameObject projectile1, projectile2;
    public GameObject[] aset;

    public float launchSpeed = 10f;

    [Header("****Trajectory Display****")]
    public LineRenderer lineRenderer;
    public int linePoints = 175, counter;
    public float timeIntervalInPoints = 0.01f;
    public Player playerscript;

    // void Update()
    // {
    //     // if(lineRenderer != null)
    //     // {
    //     //     if(Input.GetMouseButton(1))
    //     //     {
    //     //         DrawTrajectory();
    //     //         lineRenderer.enabled = true;
    //     //     }
    //     //     else
    //     //         lineRenderer.enabled = false;
    //     // }
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         var _projectile = Instantiate(projectile, launchPoint.position, launchPoint.rotation);
    //         _projectile.GetComponent<Rigidbody>().velocity = launchSpeed * launchPoint.up;
    //     }
    // }

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

    void Start()
    {
        GameObject.Find("PlayBtn").SetActive(false);

        foreach (GameObject g in UI)
            g.SetActive(true);

        StartCoroutine(StartSpawning());
        counter = 0;

    }

    void visibleFalse()
    {
        StartCoroutine(visible());
    }

    public IEnumerator visible()
    {
        yield return new WaitForSeconds(10);
        foreach (GameObject g in UI)
            g.SetActive(false);
        foreach (GameObject g in aset)
            g.SetActive(false);
        
        playerscript.WinLoseText();
        StopCoroutine(visible());
        //playerscript.WinLoseText();
    }

    public IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(1);

        var _projectile = Instantiate(projectile1, launchPoint1.position, Quaternion.Euler(new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f))));
        _projectile.GetComponent<Rigidbody>().velocity = launchSpeed * launchPoint1.up * 5;
        if (counter < 30){
            counter++;
            StartCoroutine(StartSpawning1());
        } 
        else 
        {
            StopCoroutine(StartSpawning());
            visibleFalse();
        }
    }

    public IEnumerator StartSpawning1()
    {
        yield return new WaitForSeconds(1);

        var _projectile1 = Instantiate(projectile2, launchPoint2.position, Quaternion.Euler(new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f))));
        _projectile1.GetComponent<Rigidbody>().velocity = launchSpeed * launchPoint2.up * 5;
        if (counter < 30){
            counter++;
            StartCoroutine(StartSpawning());
        }
        else 
        {
            StopCoroutine(StartSpawning1());
            visibleFalse();
        }
    }
}