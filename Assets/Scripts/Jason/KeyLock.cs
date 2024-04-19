using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyLock : MonoBehaviour
{
    public Key key;
    public ExitLevelScript exit;
    public bool doorIsLocked = true;
    private bool inTriggerZone = false;
    public TMP_Text text;
    public GameObject dialogueBox;
    public GameObject dialogueBox2;
    public GameObject realKey;

    // Start is called before the first frame update
    void Start()
    {
        key = GameObject.FindGameObjectWithTag("Key").GetComponent<Key>();
        GameObject.FindGameObjectWithTag("Exit").GetComponent<ExitLevelScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inTriggerZone == true && Input.GetKeyDown(KeyCode.E) && key.playerHasKey == true)
        {
            
            doorIsLocked = false;
            BannerDialogue.hasShown = false;
            dialogueBox2.SetActive(true);
            dialogueBox2.SetActive(false);
            realKey.GetComponent<SpriteRenderer>().enabled = false;
            exit.animator.SetBool("isUnlocked", true);
        }
        else if (inTriggerZone == true && Input.GetKeyDown(KeyCode.E) && key.playerHasKey == false)
        {
            BannerDialogue.hasShown = false;
            dialogueBox.SetActive(true);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inTriggerZone = true;
            text.text = "PRESS [e] TO UNLOCK EXIT DOOR";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTriggerZone = false;
        text.text = " ";
    }
}
