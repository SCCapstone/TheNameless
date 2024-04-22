using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;
using UnityEngine.UI;

public class BannerDialogue : MonoBehaviour
{
    
    [SerializeField] AudioSource walk;
    public Rigidbody2D rb;
    public Animator animator;
    [SerializeField] string[] text;
    [SerializeField] Sprite[] icons;
    [SerializeField] TextMeshProUGUI display;
    [SerializeField] GameObject textBox;
    [SerializeField] KeyCode advance = KeyCode.Space;
    [SerializeField] float timeBetweenChars;
    [SerializeField] PlayerMovement pm;
    [SerializeField] Image talkingIcon;
    public static bool hasShown = false;
    private int i = 0;
    private bool isShowing = false;
    private bool skipped = false;

    private MovingPlatform[] movingPlatforms;
    private float[] platformSpeeds;

   
    private void Start()
    {
        // stop moving platforms during dialogue
        movingPlatforms = (MovingPlatform[]) FindObjectsOfType(typeof(MovingPlatform));
        platformSpeeds = new float[movingPlatforms.Length];
            for (int i = 0; i < movingPlatforms.Length; i++) {
            platformSpeeds[i] = movingPlatforms[i]._speed;
        }
        // if dialogue has previously shown, do not display it again
        if (hasShown) 
        {
            textBox.SetActive(false);
        }
        // stop player movement and animations during dialogue
        else
        {
            PopulateText();
            rb.velocity = Vector3.zero;
            animator.SetBool("isRunning", false);
            walk.Pause();
            pm.enabled = false;
        }
    }

    // listen for player to advance the dialogue
    // if dialogue is still scrolling, skip to the end. If it is not scrolling, populate next line
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
        // populate the text with the appropriate line of text and icon with the correlated icon
        if(i <= text.Length - 1)
        {
            foreach(MovingPlatform movingPlatform in movingPlatforms) {
                movingPlatform._speed = 0;
            }
            if(icons.Length > 1)
            {
                talkingIcon.sprite = icons[i];
            }
            display.text = text[i];
            StartCoroutine(WriteText());
        }
        // if no more lines of text, then disable the text box and reinable the moving platforms
        else
        {
            for (int i = 0; i < movingPlatforms.Length; i++) {
                movingPlatforms[i]._speed = platformSpeeds[i];
            }
            display.text = "";
            textBox.SetActive(false);
            hasShown = true;
            pm.enabled = true;
        }
    }

    IEnumerator WriteText()
    {
        // setup for scrolling text
        isShowing = true;
        display.ForceMeshUpdate();
        int totalVisibleChars = display.textInfo.characterCount;
        int counter = 0;

        // loop that runs while the characters are slowly being made visible
        while(true)
        {
            // inc number of visible characters
            int visible = counter % (totalVisibleChars + 1);
            
            // if player skips dialogue, display the entire line at once
            if (skipped)
            {
                visible = totalVisibleChars;
                skipped = false;
            }
            display.maxVisibleCharacters = visible;

            // if all characters are visible, break out of loop and iterate to next line of text
            if (visible >= totalVisibleChars)
            {
                i++;
                isShowing = false;
                break;
            }
            // update the counter and wait short time till iterating through loop again
            counter++;
            yield return new WaitForSeconds(timeBetweenChars);
        }
    }
}
