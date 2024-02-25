using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    public Ballbehavior timerScript;
    private Text timerText;

    void Start()
    {
        timerText = GetComponent<Text>();
        timerScript = FindObjectOfType<Ballbehavior>();
        if (timerScript == null)
        {
            Debug.LogError("Ballbehavior not found in the scene.");
        }
    }


    void Update()
    {
        if (timerScript != null)
        {
            timerText.text = "Time: " + Mathf.CeilToInt(timerScript.timer).ToString("FO");
        }    
    }
}