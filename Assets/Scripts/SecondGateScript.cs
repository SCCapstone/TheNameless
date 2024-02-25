using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondGateScript : MonoBehaviour
{
    public GameObject redGate2;
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
        if (collision.gameObject.name.Equals("Player"))
        {
            redGate2.SetActive(false);
        }
        else
        {
            Debug.Log("Error: Button Not Detected");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
            redGate2.SetActive(true);
    }
}
