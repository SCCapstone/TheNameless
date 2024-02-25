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
        PlayerPrefs.SetInt("StartScene", startSceneIndex);
        PlayerPrefs.SetFloat("StartPosX", startPosition.x);
        PlayerPrefs.SetFloat("StartPosY", startPosition.y);
        SceneManager.LoadScene(sceneToLoad);
    }

    public void ReturnFromMiniGame()
    { 
        int miniGameSceneIndex = SceneManager.GetSceneByName("EMinigame").buildIndex;
        int startSceneIndex = PlayerPrefs.GetInt("StartSceneIndex");
        float startPosX = PlayerPrefs.GetFloat("StartPosX");
        float startPosY = PlayerPrefs.GetFloat("StartPosY");

        SceneManager.UnloadSceneAsync(miniGameSceneIndex);
        SceneManager.LoadScene(startSceneIndex);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = new Vector3(startPosX, startPosY, player.transform.position.z);
        }

    }
}
