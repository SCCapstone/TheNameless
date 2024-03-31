using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;
using UnityEngine.UI;

public class DoDialogueAndGoToNextLevel : MonoBehaviour
{
    // TODO : stop player from moving when text is active. TODO IS DONE
    [SerializeField] AudioSource walk;
    public Rigidbody2D rb;
    public Animator animator;
    public ExitLevelScriptV2 exitLevel;
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
        exitLevel = GameObject.FindGameObjectWithTag("Exit").GetComponent<ExitLevelScriptV2>();
        movingPlatforms = (MovingPlatform[])FindObjectsOfType(typeof(MovingPlatform));
        platformSpeeds = new float[movingPlatforms.Length];
        for (int i = 0; i < movingPlatforms.Length; i++)
        {
            platformSpeeds[i] = movingPlatforms[i]._speed;
        }
        if (hasShown)
        {
            textBox.SetActive(false);
        }
        else
        {
            PopulateText();
            rb.velocity = Vector3.zero;
            animator.SetBool("isRunning", false);
            walk.Pause();
            pm.enabled = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(advance) && !isShowing)
        {
            PopulateText();
        }
        else if (Input.GetKeyDown(advance) && isShowing)
        {
            skipped = true;
        }
    }

    private void PopulateText()
    {
        if (i <= text.Length - 1)
        {
            foreach (MovingPlatform movingPlatform in movingPlatforms)
            {
                movingPlatform._speed = 0;
            }
            if (icons.Length > 1)
            {
                talkingIcon.sprite = icons[i];
            }
            display.text = text[i];
            StartCoroutine(WriteText());
        }
        else
        {
            for (int i = 0; i < movingPlatforms.Length; i++)
            {
                movingPlatforms[i]._speed = platformSpeeds[i];
            }
            display.text = "";
            textBox.SetActive(false);
            hasShown = true;
            pm.enabled = true;
            exitLevel.GoToNextLevel();
        }
    }

    IEnumerator WriteText()
    {
        isShowing = true;
        display.ForceMeshUpdate();
        int totalVisibleChars = display.textInfo.characterCount;
        int counter = 0;

        while (true)
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
