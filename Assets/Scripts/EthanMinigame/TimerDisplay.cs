using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    public NewBehaviourScript gameScript;
    private Text timerText;

    void Start()
    {
        timerText = GetComponent<Text>();
        gameScript = FindObjectOfType<NewBehaviourScript>();
        if (gameScript == null)
        {
            Debug.LogError("NewBehaviourScript not found in the scene.");
        }
    }


    void Update()
    {
        if (gameScript != null)
        {
            timerText.text = "Time: " + Mathf.CeilToInt(gameScript.timer).ToString();
        }    
    }
}