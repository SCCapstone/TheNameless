using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ExitLevelScriptV3 : MonoBehaviour
{
    public Animator animator;
    private bool inTriggerZone = false;
    public TMP_Text text;
    public Vector2 startGravity;
    public Animator SceneTransition;
    public int sceneToLoad;

    private void Start()
    {

    }

    private void Update()
    {
        if (inTriggerZone == true && Input.GetKeyDown(KeyCode.E))
        {
            GameObject playerObject = GameObject.Find("Player");
            Destroy(playerObject);
            animator.SetBool("isReadyToExit", true);
            StartCoroutine(PlayerExitToNextLevel());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inTriggerZone = true;
            animator.SetBool("isUnlocked", true);
            text.text = "PRESS [e] TO EXIT LEVEL";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTriggerZone = false;
        text.text = " ";
    }

    public IEnumerator PlayerExitToNextLevel()
    {
        SceneTransition.SetBool("isDead", true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneToLoad);
        //Physics2D.gravity = new Vector2(startGravity.x, startGravity.y);
        SceneTransition.SetBool("isDead", false);
    }
}
