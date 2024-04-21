using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    //Variables for automatic scene transitions in cutscenes
    public bool autoTransition;
    public float seconds;
    public int nextSceneID;
    
    // Start is called before the first frame update
    void Start()
    {
        if(autoTransition)
        {
            StartCoroutine(AutoLoad(seconds, nextSceneID));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Transition to a scene by a given index number
    public void toScene(int index)
    {
        SceneManager.LoadSceneAsync(index);
    }

    //Transition to a scene by a given scene name
    public void toScene(string name)
    {
        SceneManager.LoadSceneAsync(name);
    }

    //Transition to the next scene in build order    
    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Reload the current scene
    public void Reload()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
    
    //Quit the game
    public void Quit()
    {
        Application.Quit();
    }

    //After a specified number of seconds, transition to the given scene by ID
    public IEnumerator AutoLoad(float seconds, int ID)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadSceneAsync(ID);
    }
}
