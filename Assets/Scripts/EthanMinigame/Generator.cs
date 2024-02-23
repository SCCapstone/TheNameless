using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public Vector2Int size;
    public Vector2 offset;
    public GameObject brickPrefab;
    public int bc;

    private void Awake()
    {
        for (int i = 0; i< size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                GameObject newBrick = Instantiate(brickPrefab, transform);
                newBrick.transform.position = transform.position + new Vector3((float)((size.x-1)*.5f-i) * offset.x, j * offset.y, 0);
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
        UnityEngine.SceneManagement.SceneManager.LoadScene(7);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
