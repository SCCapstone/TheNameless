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
    //Reference to the player's sprite renderer
    private SpriteRenderer SR;
    //How much time to complete each stage
    public int stageTime;
    //How much time in current stage
    private int countdownTimer;

    //Settings for the level
    public bool requireRotation;
    public bool requireMove;
    public bool requireFlip;
    public bool requirePose;

    //Number of stages in this version of the minigame
    public int numStages;

    //Goal Targets
    public int rotError;
    public float[] goalRotation;
    public bool[] goalMustMove;
    public bool[] goalFlip;
    public int[] goalPose;

    //References to scanning hazards
    public GameObject scan1;
    public GameObject scan2;
    public GameObject scan3;
    public GameObject scan4;

    // Start is called before the first frame update
    void Start()
    {
        //Get components
        exTransform = instruction.GetComponent<Transform>();
        exSprite = instruction.GetComponent<SpriteRenderer>();
        SR = GetComponent<SpriteRenderer>();

        //Start the minigame
        StartCoroutine(PlayMinigame());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Vertical"))
        {
            float vert = Input.GetAxis("Vertical");
            //Flip
            if(requireFlip && vert > 0) SR.flipX = !SR.flipX;
            //Pose
            if(requirePose && vert < 0)
            {

            }
        }
    }

    public IEnumerator PlayMinigame()
    {
        //Buffer before game starts
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
                exSprite.flipX = goalFlip[i];
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
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            if(exSprite.flipX != SR.flipX)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            //Activate the moving hazard
            if(requireMove)
            {
                switch(Random.Range(1,5))
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    default:
                        break;
                }
            }

            yield return new WaitForSeconds(0.5f);
        }

        //Minigame Won, Load Next Scene
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
