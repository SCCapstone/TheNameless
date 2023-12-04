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
        transform.position = new Vector3(trackedObject.transform.position.x*(trackX ? 1 : 0), trackedObject.transform.position.y*(trackY ? 1 : 0), z);
    }
}
