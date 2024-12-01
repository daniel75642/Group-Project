using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class PlayerController : MonoBehaviour
{
    //Movement

    public float movespeed;
    public float groundDrag;

    float horizontalInput;
    float verticalInput;

    public float fallMultiplier;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    public float waterSpeedx;
    public float waterSpeedz;
    public float waterDrag;

    public float playerHeight;

    public Transform orientation;

    Vector3 moveDirection;

    Rigidbody rb;

    //Layer Masks

    public LayerMask whatIsGround;

    //Keybinds

    KeyCode jumpKey = KeyCode.Space;

    //Scripts

    public AirVent airVent;
    public PlayerController playerController;
    public GameManager gameManager;

    //Colliders

    public Collider playerCollider;

    //Respawning

    public float spawnx;
    public float spawny;
    public float spawnz;

    //Game Objects

    public GameObject fading;
    public GameObject player;
    public GameObject abilityChangeHint;

    //Bools

    public bool tpDone;
    public bool steamHint;
    bool grounded;


    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        ResetJump();
        tpDone = false;
        steamHint = false;
        abilityChangeHint.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (grounded)
        {
            rb.drag = groundDrag;
        }
            
        else if (!grounded)
        {
            rb.drag = 0f;
        }
            


        if (rb.velocity.y < -0.1)
        {
            rb.velocity += new Vector3(0f, fallMultiplier, 0f);
        }


        Inputs();
        MovePlayer();
        SpeedControl();
        
    }
    private void LateUpdate()
    {
        //Ground Checks and Drag

        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

    }

    private void Inputs()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //When To Jump
        
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {

            Jump();

            readyToJump = false;

            Invoke(nameof(ResetJump), jumpCooldown);
        }

    }

    private void MovePlayer()
    {
        //Calculate Move Direction

        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //Movement

        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * movespeed * 10f * Time.deltaTime, ForceMode.Force);
        }
            

        if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * movespeed * airMultiplier * 10f * Time.deltaTime, ForceMode.Force);
        }
            
    }
    private void SpeedControl()
    {
        //Gets Move Speed

        Vector3 flatVel = new Vector3 (rb.velocity.x, 0f, rb.velocity.z);

        // Limits Move Speed

        if (flatVel.magnitude > movespeed)
        {
            Vector3 limitedVel = flatVel.normalized * movespeed;
            rb.velocity = new Vector3 (limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        //Reset Y Velocity for the jump

        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

    }

    private void ResetJump()
    {
        readyToJump = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("water"))
        {
            rb.velocity = new Vector3(rb.velocity.x + waterSpeedx, rb.velocity.y, rb.velocity.z + waterSpeedz);
        }

        if (collision.gameObject.CompareTag("playerDestroy"))
        {
            rb.transform.position = new Vector3 (spawnx, spawny, spawnz);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject != null)
        {
            if (other.gameObject.CompareTag("keepOpenDoor"))
            {
                airVent.Open();
            }

            else if (other.gameObject.CompareTag("firstTp") && tpDone == false)
            {
                StartCoroutine(firstTp());
                StopCoroutine(firstTp());
            }

            else if (other.gameObject.CompareTag("SteamArea") && steamHint == false)
            {
                StartCoroutine(SteamHint());
                StopCoroutine(SteamHint());
            }

            else if (other.gameObject.CompareTag("hint1"))
            {
                gameManager.Hinting1();
            }
        }

    }

    private IEnumerator firstTp()
    {
        tpDone = true;
        fading.SetActive(true);
        playerController.enabled = false;
        rb.velocity = Vector3.zero;
        animator.SetBool("FadingOut", true);
        yield return new WaitForSeconds(2);
        player.transform.position = new Vector3(52.93f, 7.78f, 43.15f);
        animator.SetBool("OutToIn", true);
        animator.SetBool("FadingIn", true);
        yield return new WaitForSeconds(2);
        playerController.enabled = true;
        fading.SetActive(false);

    }

    private IEnumerator SteamHint()
    {
        steamHint = true;
        abilityChangeHint.SetActive(true);
        yield return new WaitForSeconds(8);
        abilityChangeHint.SetActive(false);
    }
}
