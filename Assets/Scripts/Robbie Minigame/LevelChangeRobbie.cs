using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangeRobbie : MonoBehaviour
{
    bool inProx = false;
    [SerializeField] GameObject prompt;
    void Update()
    {
        if(inProx && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("RLevelAttempt");
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
