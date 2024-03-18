using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;

public class BannerDialogue : MonoBehaviour
{
    // TODO : stop player from moving when text is active.
    [SerializeField] string[] text;
    [SerializeField] TextMeshProUGUI display;
    [SerializeField] GameObject textBox;
    [SerializeField] KeyCode advance = KeyCode.Space;
    [SerializeField] float timeBetweenChars;
    [SerializeField] PlayerMovement pm;
    public static bool hasShown = false;
    private int i = 0;
    private bool isShowing = false;
    private bool skipped = false;

   
    private void Start()
    {
        if (hasShown) 
        {
            textBox.SetActive(false);
        }
        else
        {
            PopulateText();
            pm.enabled = false;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(advance) && !isShowing)
        {
            PopulateText();
        }
        else if(Input.GetKeyDown(advance) && isShowing)
        {
            skipped = true;
        }
    }

    private void PopulateText()
    {
        if(i <= text.Length - 1)
        {
            display.text = text[i];
            StartCoroutine(WriteText());
        }
        else
        {
            display.text = "";
            textBox.SetActive(false);
            hasShown = true;
            pm.enabled = true;
        }
    }

    IEnumerator WriteText()
    {
        isShowing = true;
        display.ForceMeshUpdate();
        int totalVisibleChars = display.textInfo.characterCount;
        int counter = 0;

        while(true)
        {
            int visible = counter % (totalVisibleChars + 1);
            if (skipped)
            {
                visible = totalVisibleChars;
                skipped = false;
            }
            display.maxVisibleCharacters = visible;

            if (visible >= totalVisibleChars)
            {
                i++;
                isShowing = false;
                break;
            }
            counter++;
            yield return new WaitForSeconds(timeBetweenChars);
        }
    }
}
