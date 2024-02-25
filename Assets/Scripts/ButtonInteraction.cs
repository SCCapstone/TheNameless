using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonInteraction : MonoBehaviour
{
   // public Text ButtonText;
    public int sceneToLoad;
    private bool playerInRange;
    private int startSceneIndex;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
      startSceneIndex = SceneManager.GetActiveScene().buildIndex;
      startPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           // ButtonText.enabled = true;
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //ButtonText.enabled = false;
            playerInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            LoadMiniGame();
        }
    }

    void LoadMiniGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
