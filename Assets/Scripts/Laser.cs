using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [Header("Visual Variables")]
    // what color should the laser be?
    [SerializeField] Color color = Color.red;
    // how thick is the laser?
    [SerializeField] float thickness = 0.1f;

    [Header("Logic Variables")]
    // does the laser rotate?
    [SerializeField] bool moving = false;
    // does the laser blink?
    [SerializeField] bool blink = false;
    // where is the respawn point
    [SerializeField] Transform respawn;
    // what tag should be respawned by the laser?
    [SerializeField] string playerTag = "Player";
    // how long between blinks?
    [SerializeField] float ioTimer = 1f;
    // how long does it take the laser to move?
    [SerializeField] float rotateTimer = 2f;

    // line will show the laser
    private LineRenderer lr;
    // use raycasting to set length and detect collision
    private RaycastHit2D hit;
    private Ray2D ray;
    private Vector2 laserDir;
    // used to change the rotation direction
    private bool hasRotated = false;

    private void Start()
    {
        // access object's line renderer
        lr = GetComponent<LineRenderer>();
        lr.useWorldSpace = true;
        lr.startColor = color;
        lr.endColor = color;
        lr.startWidth = thickness;
        lr.endWidth = thickness;
    }

    private void Update()
    {
        if (blink)
        {
            StartCoroutine(BlinkHandler());
        }
        if (moving)
        {
            StartCoroutine(RotateHandler());
        }
        // create and draw laser based on laser direction
        lr.positionCount = 2;
        ray = new Ray2D(transform.position, -transform.up);
        lr.SetPosition(0, ray.origin);
        hit = Physics2D.Raycast(ray.origin, -transform.up, 10000);
        lr.SetPosition(1, hit.point);
        if (hit.collider.tag == playerTag)
        {
            print("true");
        }
        if(playerTag == "disabled")
        {
            print("done");
        }
    }

    IEnumerator BlinkHandler()
    {
        // prevent coroutine from activating while running
        blink = false;
        // disable laser and wait for the timer
        lr.enabled = false;
        string tempTag = playerTag;
        playerTag = "disabled";
        yield return new WaitForSeconds(ioTimer);
        // re-enable laser and wait for timer
        lr.enabled = true;
        playerTag = tempTag;
        yield return new WaitForSeconds(ioTimer);
        // allow for coroutine to start again
        blink = true;
    }

    IEnumerator RotateHandler()
    {
        // prevent coroutine from activating while running
        moving = false;
        // keep track of how long rotation has been going
        float currentTime = 0f;
        // set the by angle based on whether the laser has already been rotated or not
        Vector3 byAngle = hasRotated ? Vector3.forward * 90f : Vector3.back * 90f;
        
        // set the rotation angles for the interpolation
        Quaternion fromAngle = transform.rotation;
        Quaternion toAngle = Quaternion.Euler(transform.eulerAngles + byAngle);
        
        // run for the length set in rotateTimer
        while (currentTime < rotateTimer)
        {
            // soherically interpolate the angle to create smooth rotation, then inc time
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, currentTime / rotateTimer);
            currentTime += Time.deltaTime;
            yield return null;
        }
        // set the laser's rotation to exactly new angle (slerp can be slightly off)
        transform.rotation = toAngle;
        hasRotated = !hasRotated;

        yield return new WaitForSeconds(rotateTimer / 2);
        // allow for coroutine to start again
        moving = true;
    }
}
