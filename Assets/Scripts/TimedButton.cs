using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedButton : MonoBehaviour
{
    public GameObject linkedObject;
    public float timerLength;
    public bool timed;
    public bool timerRunning;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !timerRunning)
        {
            linkedObject.SetActive(false);
            if(timed)
            {
                timerRunning = true;
                StartCoroutine(ButtonReset(timerLength));
            }
        }
    }

    IEnumerator ButtonReset(float secs)
    {
        yield return new WaitForSeconds(secs);
        linkedObject.SetActive(true);
        timerRunning = false;
    }
}
