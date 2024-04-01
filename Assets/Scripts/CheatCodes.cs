using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatCodes : MonoBehaviour
{
    [SerializeField] public string Buffer;
    [SerializeField] private float maxTimeDif = 1;
    private List<string> validPatterns = new List<string>() {"BBL","BBB"};
    private float timeDif;

    private bool cheatOnCooldown;

    // Start is called before the first frame update
    void Start()
    {
        timeDif = maxTimeDif;
    }

    // Update is called once per frame
    void Update()
    {
        timeDif -= Time.deltaTime;
        if(timeDif <= 0 )
        {
            Buffer = string.Empty;
        }

        if (Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") > 0)
        {
            addToBuffer("U");
        }
        else if (Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") < 0)
        {
            addToBuffer("D");
        }
        else if (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") > 0)
        {
            addToBuffer("R");
        }
        else if (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") < 0)
        {
            addToBuffer("L");
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            addToBuffer("B");
        }

        if(!cheatOnCooldown) checkPatterns();
    }

    void addToBuffer(string c)
    {
        timeDif = maxTimeDif;
        Buffer += c;
    }

    void checkPatterns()
    {
        if (Buffer.EndsWith(validPatterns[0]))
        {
            PlayerHealth.invincibility = !PlayerHealth.invincibility;
            cheatOnCooldown = true;
            TextActivator.en = true;
            Invoke("QuickDisable", 3f);
            StartCoroutine(CheatCooldown());
        }
        if (Buffer.EndsWith(validPatterns[1]))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void QuickDisable()
    {
        TextActivator.en = false;
    }

    private IEnumerator CheatCooldown()
    {
        yield return new WaitForSeconds(maxTimeDif);
        cheatOnCooldown = false;
    }
}
