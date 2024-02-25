using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public Vector2Int size;
    public Vector2 offset;
    public GameObject brickPrefab;
    public Gradient gradient;
    private int bc;
    public int WinScene;

    private void Awake()
    {
        for (int i = 0; i< size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                GameObject newBrick = Instantiate(brickPrefab, transform);
                newBrick.transform.position = transform.position + new Vector3((float)((size.x-1)*.5f-i) * offset.x, j * offset.y, 0);
                newBrick.GetComponent<SpriteRenderer>().color = gradient.Evaluate((float)j / (size.y - 1));
                bc++;
            }
        }
    }
    public void DestroyBrick()
    {
        bc--;
        if(bc <= 0)
        {
            LoadNewScene();
        }
    }
    private void LoadNewScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(WinScene);
    }
}
