using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MusicBehavior : MonoBehaviour
{ 

    private static MusicBehavior instance;
    public AudioSource audioSource;
    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    private void Update()
    {
        int y = SceneManager.GetActiveScene().buildIndex;
        if (y == 0)
        {
            MuteMusic();
        }
    }

    public void MuteMusic()
    {
        if (audioSource != null)
        {
            Destroy(gameObject);
        }
    }
}
