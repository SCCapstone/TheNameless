using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PoseMinigame : MonoBehaviour
{
    //Reference to countdown text
    public TMP_Text countdown;
    //Reference to visible example
    public GameObject instruction;
    private Transform exTransform;
    private SpriteRenderer exSprite;
    //How much time to complete each stage
    public int stageTime;
    //How much time in current stage
    private int countdownTimer;

    //Settings for the level
    public bool requireRotation;
    public bool requireMove;
    public bool requireFlip;
    public bool requirePose;

    public int numStages;

    public int rotError;
    public float[] goalRotation;
    public bool[] goalMustMove;
    public bool[] goalFlip;
    public int[] goalPose; 

    // Start is called before the first frame update
    void Start()
    {
        exTransform = instruction.GetComponent<Transform>();
        exSprite = instruction.GetComponent<SpriteRenderer>();

        StartCoroutine(PlayMinigame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator PlayMinigame()
    {
        yield return new WaitForSeconds(1);
        
        //Loop for each stage
        for(int i=0; i<numStages; i++)
        {
            //Display goal
            if(requireRotation)
            {
                exTransform.rotation = Quaternion.Euler(0, 0, goalRotation[i]);
            }
            if(requireFlip)
            {

            }
            if(requirePose)
            {

            }

            //Wait for countdown
            for(countdownTimer = stageTime; countdownTimer>=0; countdownTimer--)
            {
                countdown.text = "" + countdownTimer;
                yield return new WaitForSeconds(1);
            }

            float checkedRot = transform.eulerAngles.z;
            //Check for failure
            if(requireRotation && (checkedRot<goalRotation[i]-rotError || checkedRot>goalRotation[i]+rotError))
            {
                Debug.Log(checkedRot);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            yield return new WaitForSeconds(0.5f);
        }

        //Minigame Won, Load Next Scene
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
