using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangeRobbie : MonoBehaviour
{
    bool inProx = false;
    [SerializeField] GameObject prompt;
    [SerializeField] int LevelIndex;
    void Update()
    {
        if(inProx && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(LevelIndex);
            BannerDialogue.hasShown = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inProx = true;
        prompt.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        inProx = false;
        prompt.SetActive(false);
    }
}
