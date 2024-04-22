using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextActivator : MonoBehaviour
{
    public static bool en = false;
    private TMP_Text m_TextComponent;

    // reference to TMP component
    void Awake()
    {
        m_TextComponent = GetComponent<TMP_Text>();
    }

    // checks if en is true every frame, and displays text if so
    void Update()
    {
        if (en)
        {
            if(PlayerHealth.invincibility)
            {
                m_TextComponent.text = "Invincibilty Enabled";
            }
            else
            {
                m_TextComponent.text = "Invincibilty Disabled";
            }
            m_TextComponent.enabled = true;
        } 
        else
        {
            m_TextComponent.enabled = false; 
        }
    }
}
