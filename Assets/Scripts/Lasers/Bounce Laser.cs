using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceLaser : MonoBehaviour
{
    private GameObject laserSrc;
    private LineRenderer lineRenderer;
    private LineRenderer lr;
    private Ray2D ray;
    private RaycastHit2D hit;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    public void SetLaserSource(GameObject src)
    {
        laserSrc = src;
        lineRenderer = laserSrc.GetComponent<LineRenderer>();
        lr.startColor = lineRenderer.startColor;
        lr.endColor = lineRenderer.endColor;
        lr.startWidth = lineRenderer.startWidth;
        lr.endWidth = lineRenderer.endWidth;
    }

    private void Update()
    {
        if (laserSrc != null)
        {
            Vector2 inDir = (lineRenderer.GetPosition(1) - lineRenderer.GetPosition(0)).normalized;
            Vector2 newDir = Vector2.Reflect(inDir, lineRenderer.GetPosition(1).normalized);

            ray = new Ray2D(lineRenderer.GetPosition(1), newDir);
            lr.positionCount = 2;
            lr.SetPosition(0, lineRenderer.GetPosition(1));
            hit = Physics2D.Raycast(ray.origin, newDir, 10000);
            lr.SetPosition(1, hit.point);
            Debug.DrawRay(ray.origin, ray.direction, Color.red);

            if (hit.collider.tag == laserSrc.GetComponent<Laser>().playerTag)
            {
                print(true);
            }
            else if (hit.collider.tag == "Bounce")
            {
                hit.collider.gameObject.GetComponent<BounceLaser>().SetLaserSource(gameObject);
            }
        }
    }
}
