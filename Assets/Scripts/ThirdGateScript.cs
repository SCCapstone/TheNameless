using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdGateScript : MonoBehaviour
{
    public GameObject redGate3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            redGate3.SetActive(false);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        redGate3.SetActive(true);
    }
}
