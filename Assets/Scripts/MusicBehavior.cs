using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MusicBehavior : MonoBehaviour
{
    private static MusicBehavior instance;
    private void Awake()
    {
        int y = SceneManager.GetActiveScene().buildIndex;
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else if (y == 0)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
