using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WireManager2 : MonoBehaviour
{
    public List<bool> connections;
    [SerializeField] int numWires = 4;
    [SerializeField] GameObject GO;
    [SerializeField] GameObject Panel;
    public Animator wireAnimator;
    
    // connections list will hold the number of successful wire connections
    private void Start()
    {
        connections = new List<bool>();
    }

    
    void Update()
    {
        // if there are as many connections as wires, then update the door/laser and disable the puzzle panel
        if(connections.Count == numWires)
        {
            // check of object is a laser
            if(GO.GetComponent<Laser>() != null)
            {
                GO.GetComponent<Laser>().enabled = false;
                GO.GetComponent<LineRenderer>().positionCount = 0;
                GO.GetComponent<LineRenderer>().enabled = false;
            }
            // if not a laser, remove object
            else
            {
                GO.SetActive(false);
            }
            Panel.SetActive(false);
            wireAnimator.SetBool("isWired", true);
        }
    }

    // called by the wire, adds entries to the list of successful connections
    public void SuccessfulConnection()
    {
        connections.Add(true);
    }
}
