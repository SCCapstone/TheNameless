using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInteraction : MonoBehaviour
{
    public Text ButtonText;
    public string sceneToLoad;
    private bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        ButtonText.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Astronaught"))
        {
            ButtonText.enabled = true;
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Astronaught"))
        {
            ButtonText.enabled = false;
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
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
    }
}
