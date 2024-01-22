using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Pause();
        }
        
    }
    public void menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Pause() {
        pauseMenu.SetActive(true);
        //Time.timescale(0f);
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        //Time.timescale(1f);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
