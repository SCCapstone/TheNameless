using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLevelScript : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        player.SetActive(false);
        StartCoroutine(SetPlayerActive());
    }

    public IEnumerator SetPlayerActive()
    {
        yield return new WaitForSeconds(1);
        player.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
