using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicScript : MonoBehaviour
{
    private static MenuMusicScript instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
    }
}
