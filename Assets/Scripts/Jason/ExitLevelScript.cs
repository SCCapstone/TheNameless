using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine.SceneManagement;

public class ExitLevelScript : MonoBehaviour
{
    public Animator animator;
    private bool inTriggerZone = false;
    public TMP_Text text;
    public KeyLock keyLock;
    public Vector2 startGravity;
    public Animator SceneTransition;

    private void Start()
    {
        keyLock = GameObject.FindGameObjectWithTag("KeyLock").GetComponent<KeyLock>();

    }

    private void Update()
    {
        if (inTriggerZone == true && Input.GetKeyDown(KeyCode.E) && keyLock.doorIsLocked == false)
        {
            GameObject playerObject = GameObject.Find("Player");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            animator.SetBool("isReadyToExit", true);
            Destroy(playerObject);
            
        }
        else
        {
            Debug.Log("Exit Level Error");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inTriggerZone = true;
            text.text = "PRESS [E] TO EXIT LEVEL";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTriggerZone = false;
    }

    public IEnumerator PlayerExitToNextLevel()
    {
        SceneTransition.SetBool("isDead", true);
        yield return new WaitForSeconds(2);
        
        Physics2D.gravity = new Vector2(startGravity.x, startGravity.y);
        SceneTransition.SetBool("isDead", false);
    }
}
