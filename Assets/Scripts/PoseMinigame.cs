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

    private int currentPose;

    //Respawn
    public AudioSource hurt;
    private bool hasDied = false;
    public Rigidbody2D rb;
    private bool invincibility = PlayerHealth.invincibility;
    public Animator animator;
    public Animator SceneTransition;
    private bool hasFailed = false;

    // Start is called before the first frame update
    void Start()
    {
        //Get reference
        rb = GetComponent<Rigidbody2D>();
        
        //Start on pose 0
        currentPose = 0;

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
            //Flip if minigame allows
            if(requireFlip && vert > 0)
            {
                SR.flipX = !SR.flipX;
            }
            //Pose if minigame allows
            if(requirePose && vert < 0)
            {
                //Increment current pose, which cycles between 0, 1, and 2
                currentPose = (currentPose+1) % 3;

                //Display the correct pose
                switch(currentPose)
                {
                    case 0:
                        SR.sprite = Resources.Load<Sprite>("Astronaut_Pose1");
                        break;
                    case 1:
                        SR.sprite = Resources.Load<Sprite>("Astronaut_Pose2");
                        break;
                    case 2:
                        SR.sprite = Resources.Load<Sprite>("Astronaut_Pose3");
                        break;
                    default:
                        break;
                }
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
                switch(goalPose[i])
                {
                    case 0:
                        exSprite.sprite = Resources.Load<Sprite>("Astronaut_Pose1");
                        break;
                    case 1:
                        exSprite.sprite = Resources.Load<Sprite>("Astronaut_Pose2");
                        break;
                    case 2:
                        exSprite.sprite = Resources.Load<Sprite>("Astronaut_Pose3");
                        break;
                    default:
                        break;
                }
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
                hasFailed = true;
            }
            if(exSprite.flipX != SR.flipX)
            {
                hasFailed = true;
            }
            if(requirePose && currentPose != goalPose[i])
            {
                hasFailed = true;
            }

            if(hasFailed)
            {
                FailMinigame();
                yield return new WaitForSeconds(5);
            }
            //Emergency correct
            hasFailed = false;

            //Wait a bit between the completion of each phase
            yield return new WaitForSeconds(0.5f);
        }

        //Minigame Won, Load Next Scene
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FailMinigame()
    {
        //Do nothing if invincibility cheat is active
        if (invincibility == true)
        {
            return;
        }

        //Start animating
        animator.enabled = true;

        //Stop movement
        rb.bodyType = RigidbodyType2D.Static;
        rb.velocity = Vector3.zero;
        animator.SetBool("isElectrocuted", true);
        
        if (!hasDied)
        {
            //Play death sound
            hurt.PlayOneShot(hurt.clip);
            hasDied = true;
        }

        //Start to respawn
        StartCoroutine(PlayerRespawn());
    }

    public IEnumerator PlayerRespawn()
    {
        //Give time for death animation to play
        yield return new WaitForSeconds(1);
        //Fade out of scene
        SceneTransition.SetBool("isDead", true);
        yield return new WaitForSeconds(3);
        //Reload level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
