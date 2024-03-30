using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLevelScript : MonoBehaviour
{
    public GameObject player;
    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        player.GetComponent<SpriteRenderer>().enabled = false;
        playerMovement.enabled = false;
        StartCoroutine(SetPlayerActive());
    }

    public IEnumerator SetPlayerActive()
    {
        yield return new WaitForSeconds(1);
        player.GetComponent<SpriteRenderer>().enabled = true;
        playerMovement.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
