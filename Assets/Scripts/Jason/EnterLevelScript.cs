using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLevelScript : MonoBehaviour
{
    // Variable declarations
    public GameObject player;
    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    private MovingPlatform[] movingPlatforms;
    private float[] platformSpeeds;


    // Assigns moving platforms their speed when entering a level
    // Disables player movement during entrance animation and
    // Enables it when it is done
    void Start()
    {
        movingPlatforms = (MovingPlatform[]) FindObjectsOfType(typeof(MovingPlatform));
        platformSpeeds = new float[movingPlatforms.Length];
            for (int i = 0; i < movingPlatforms.Length; i++) {
            platformSpeeds[i] = movingPlatforms[i]._speed;
        }
        GameObject player = GameObject.Find("Player");
        player.GetComponent<SpriteRenderer>().enabled = false;
        playerMovement.enabled = false;
        StartCoroutine(SetPlayerActive());
    }

    // Allows the player to move after the enter animation is done
    public IEnumerator SetPlayerActive()
    {
        yield return new WaitForSeconds(1);
        player.GetComponent<SpriteRenderer>().enabled = true;
        playerMovement.enabled = true;
    }

    // Update is called once per frame
    // Assigns moving platforms their speeds during level
    void Update()
    {
        if (!player.GetComponent<SpriteRenderer>().enabled || !BannerDialogue.hasShown)
        {
            foreach(MovingPlatform movingPlatform in movingPlatforms) {
                movingPlatform._speed = 0;
            }
        }
        else
        {
            for (int i = 0; i < movingPlatforms.Length; i++) {
                movingPlatforms[i]._speed = platformSpeeds[i];
            }
        }
    }

}
