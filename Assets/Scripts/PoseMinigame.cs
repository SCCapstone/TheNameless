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
        rb = GetComponent<Rigidbody2D>();
        
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
            //Flip
            if(requireFlip && vert > 0)
            {
                SR.flipX = !SR.flipX;
            }
            //Pose
            if(requirePose && vert < 0)
            {
                currentPose = (currentPose+1) % 3;

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

            yield return new WaitForSeconds(0.5f);
        }

        //Minigame Won, Load Next Scene
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FailMinigame()
    {
        if (invincibility == true)
        {
            return;
        }

        rb.bodyType = RigidbodyType2D.Static;
        rb.velocity = Vector3.zero;
        animator.SetBool("isElectrocuted", true);
        
        if (!hasDied)
        {
            hurt.PlayOneShot(hurt.clip);
            hasDied = true;
        }
        StartCoroutine(PlayerRespawn());
    }

    public IEnumerator PlayerRespawn()
    {
        yield return new WaitForSeconds(1);
        SceneTransition.SetBool("isDead", true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
