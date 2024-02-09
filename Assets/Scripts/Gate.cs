using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] public bool open = false;
    [SerializeField] private bool isHorizontal;
    private Vector3 startScale;

    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
            OpenGate();
        else
            CloseGate();
        
    }

    public void OpenGate()
    {
        Vector3 scale = transform.localScale;
        if (isHorizontal && scale.x > 0)
            scale.x -= 0.1f;
        if (!isHorizontal && scale.y > 0)
            scale.y -= 0.1f;
        transform.localScale = scale;
    }

    public void CloseGate()
    {
        Vector3 scale = transform.localScale;
        if (isHorizontal && scale.x < startScale.x)
            scale.x += 0.1f;
        if (!isHorizontal && scale.y < startScale.y)
            scale.y += 0.1f;
        transform.localScale = scale;
    }

    public void ToggleOpen()
    {
        open = !open;
    }
}
