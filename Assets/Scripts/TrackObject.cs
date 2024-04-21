using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackObject : MonoBehaviour
{
    //The object to track
    public GameObject trackedObject;
    //Whether to copy the object's X position
    public bool trackX;
    //Whether to copy the object's Y position
    public bool trackY;
    //The Z position for this object
    public float z;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((trackX ? trackedObject.transform.position.x : transform.position.x), (trackY ? trackedObject.transform.position.y : transform.position.y), z);
    }
}
