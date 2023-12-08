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
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            pauseMenu.SetActive(!pauseMenu.activeInHierarchy);

        }
        
    }
    public void menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
