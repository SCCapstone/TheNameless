using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextActivator : MonoBehaviour
{
    public static bool en = false;
    private TMP_Text m_TextComponent;

    void Awake()
    {
        m_TextComponent = GetComponent<TMP_Text>();
        m_TextComponent.text = "Invincibilty Enabled";
    }

    // Update is called once per frame
    void Update()
    {
        if (en)
        {
            m_TextComponent.enabled = true;
        } 
        else
        {
            m_TextComponent.enabled = false; 
        }
    }
}
