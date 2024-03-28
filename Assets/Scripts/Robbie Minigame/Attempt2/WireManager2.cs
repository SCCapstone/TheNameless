using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WireManager2 : MonoBehaviour
{
    List<bool> connections;
    [SerializeField] int numWires = 4;
    private void Start()
    {
        connections = new List<bool>();
    }

    // Update is called once per frame
    void Update()
    {
        if(connections.Count == numWires)
        {
            // Todo: turn on/off object or script (bool?)
        }
    }

    public void SuccessfulConnection()
    {
        connections.Add(true);
        Debug.Log(connections.Count);
    }
}
