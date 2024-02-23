using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerDisplay : MonoBehaviour
{
    public Ballbehavior timerScript;
    private TMP_Text timerText;

    void Start()
    {
        timerText = GetComponent<TMP_Text>();
        if (timerScript == null)
        {
            Debug.LogError("Ballbehavior not found in the scene.");
        }
    }


    void Update()
    {
        if (timerScript != null)
        {
            timerText.text = "Time: " + Mathf.CeilToInt(timerScript.timer);
        }    
    }
}