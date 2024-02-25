using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackObject : MonoBehaviour
{
    public GameObject trackedObject;
    public bool trackX;
    public bool trackY;
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
