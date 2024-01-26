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

    public void toScene(int index)
    {
        SceneManager.LoadSceneAsync(index);
    }

    public void toScene(string name)
    {
        SceneManager.LoadSceneAsync(name);
    }
    
    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Reload()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
    
    public void Quit()
    {
        Application.Quit();
    }

    public IEnumerator AutoLoad(float seconds, int ID)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadSceneAsync(ID);
    }
}
