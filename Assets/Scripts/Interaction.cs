using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    //Variables

    public float interactDistance;
    public float x;
    public float y;
    public float z;

    //Keybinds

    KeyCode interact = KeyCode.E;

    //Transforms

    public Transform objectGrabPointTransform;
    public Transform playerCameraTransform;

    //Layer Masks

    public LayerMask grabableLayerMask;
    public LayerMask pipeLayer;

    //Scripts
    
    private ObjectGrabable objectGrabable;
    private SwivelThing swivelThing;
    private SteamSwivelThing steamSwivelThing;
    public PlayerController controller;
    public ReticleChange reticleChange;
    public GameManager gameManager;

    //Bools

    private bool used;
    private bool steamUsed;
    private bool pipeHeld;
    private bool pipe1Held;
    private bool pipe2Held;
    private bool pipe3Held;
    private bool pipe4Held;
    private bool pipe5Held;
    private bool pipe6Held;
    private bool pipe1Done;
    private bool pipe2Done;
    private bool pipe3Done;
    private bool pipe4Done;
    private bool pipe5Done;
    private bool pipe6Done;
    private bool pipesDone;
    private bool pipesDone2;
    private bool hint2Done;

    //Game Objects

    public GameObject pipe1;
    public GameObject pipe2;
    public GameObject pipe3;
    public GameObject pipe4;
    public GameObject pipe5;
    public GameObject pipe6;
    public GameObject player;
    public GameObject fading;
    public GameObject hint2;

    //Rigidbody's

    public Rigidbody pipe1Rb;
    public Rigidbody pipe2Rb;
    public Rigidbody pipe3Rb;
    public Rigidbody pipe4Rb;
    public Rigidbody pipe5Rb;
    public Rigidbody pipe6Rb;
    public Rigidbody playerRb;
    public Rigidbody boxRb;

    //Animator

    public Animator animator;

    // Start is called before the first frame update
    private void Start()
    {
        used = false;
        steamUsed = false;
        pipeHeld = false;
        pipe1Held = false;
        pipe2Held = false; 
        pipe3Held = false;
        pipe4Held = false;
        pipe5Held = false;
        pipe6Held = false;
        pipe1Done = false;
        pipe2Done = false;
        pipe3Done = false;
        pipe4Done = false;
        pipe5Done = false;
        pipe6Done = false;
        pipesDone = true;
        pipesDone2 = true;
        hint2Done = false;
        hint2.SetActive(false);
        fading.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(interact))  
        {
            if (objectGrabable == null)
            {
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, interactDistance, grabableLayerMask) && pipeHeld == false)
                {
                    if (raycastHit.transform.TryGetComponent(out objectGrabable) && raycastHit.transform.gameObject.CompareTag("box"))
                    {
                        reticleChange.objectGrabbed = true;
                        objectGrabable.Grab(objectGrabPointTransform);
                        return;
                    }

                    else if (raycastHit.transform.TryGetComponent(out objectGrabable) && raycastHit.transform.gameObject.CompareTag("pipe1") && pipe1Done == false)
                    {
                        reticleChange.objectGrabbed = true;
                        objectGrabable.Grab(objectGrabPointTransform);
                        pipe1Held = true;
                        pipeHeld = true;
                        if (hint2Done == false)
                        {
                            Hint2Yh();
                        }
                        return;
                    }
                    
                    else if (raycastHit.transform.TryGetComponent(out objectGrabable) && raycastHit.transform.gameObject.CompareTag("pipe2") && pipe2Done == false)
                    {
                        reticleChange.objectGrabbed = true;
                        objectGrabable.Grab(objectGrabPointTransform);
                        pipe2Held = true;
                        pipeHeld = true;
                        if (hint2Done == false)
                        {
                            Hint2Yh();
                        }
                        return;
                    }

                    else if (raycastHit.transform.TryGetComponent(out objectGrabable) && raycastHit.transform.gameObject.CompareTag("pipe3") && pipe3Done == false)
                    {
                        reticleChange.objectGrabbed = true;
                        objectGrabable.Grab(objectGrabPointTransform);
                        pipe3Held = true;
                        pipeHeld = true;
                        if (hint2Done == false)
                        {
                            Hint2Yh();
                        }
                        return;
                    }

                    else if (raycastHit.transform.TryGetComponent(out objectGrabable) && raycastHit.transform.gameObject.CompareTag("pipe4") && pipe4Done == false)
                    {
                        reticleChange.objectGrabbed = true;
                        objectGrabable.Grab(objectGrabPointTransform);
                        pipe4Held = true;
                        pipeHeld = true;
                        return;
                    }

                    else if (raycastHit.transform.TryGetComponent(out objectGrabable) && raycastHit.transform.gameObject.CompareTag("pipe5") && pipe5Done == false)
                    {
                        reticleChange.objectGrabbed = true;
                        objectGrabable.Grab(objectGrabPointTransform);
                        pipe5Held = true;
                        pipeHeld = true;
                        return;
                    }

                    else if (raycastHit.transform.TryGetComponent(out objectGrabable) && raycastHit.transform.gameObject.CompareTag("pipe6") && pipe6Done == false)
                    {
                        reticleChange.objectGrabbed = true;
                        objectGrabable.Grab(objectGrabPointTransform);
                        pipe6Held = true;
                        pipeHeld = true;
                        return;
                    }

                    else if (raycastHit.transform.TryGetComponent(out swivelThing) && used == false)
                    {
                        used = true;
                        swivelThing.MovePlatform();
                        swivelThing.DoorOpen();
                        return;
                    }

                    else if (raycastHit.transform.TryGetComponent(out steamSwivelThing) && steamUsed == false)
                    {
                        steamUsed = true;
                        steamSwivelThing.StartCrane();
                        return;
                    }

                    else if (raycastHit.transform.gameObject.CompareTag("ladder"))
                    {
                        player.transform.position = new Vector3(-11.82f, 5.797f, -30f);
                        return;
                    }

                    else if (raycastHit.transform.gameObject.CompareTag("ladder2"))
                    {
                        player.transform.position = new Vector3(-11.116f, 22.508f, -25.572f);
                        return;
                    }

                    else if (raycastHit.transform.gameObject.CompareTag("ladder3"))
                    {
                        player.transform.position = new Vector3(-12.9f, 29.116f, -28.95f);
                        return;
                    }

                    else if (raycastHit.transform.gameObject.CompareTag("blimp"))
                    {
                        StartCoroutine(Blimp());
                    }
                }
            }
            else if (pipeHeld == true)
            {
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit Hit, interactDistance, pipeLayer))
                {
                    if (Hit.transform.gameObject.CompareTag("pipePlace1") && pipe1Held == true)
                    {
                        pipe1Held = false;
                        pipeHeld = false;
                        reticleChange.objectGrabbed = false;
                        objectGrabable.Drop();
                        objectGrabable = null;
                        pipe1Rb.velocity = Vector3.zero;
                        pipe1.transform.position = new Vector3(45.986f, -0.149f, -25.468f);
                        pipe1.transform.rotation = Quaternion.Euler(-180f, -167.689f, 0);
                        pipe1Rb.constraints = RigidbodyConstraints.FreezeAll;
                        pipe1Done = true;
                        return;
                    }

                    else if (Hit.transform.gameObject.CompareTag("pipePlace2") && pipe2Held == true)
                    {
                        pipe2Held = false;
                        pipeHeld = false;
                        reticleChange.objectGrabbed = false;
                        objectGrabable.Drop();
                        objectGrabable = null;
                        pipe2Rb.velocity = Vector3.zero;
                        pipe2.transform.position = new Vector3(46.297f, 0.914f, -24.331f);
                        pipe2.transform.rotation = Quaternion.Euler(0, -167.69f, 0);
                        pipe2Rb.constraints = RigidbodyConstraints.FreezeAll;
                        pipe2Done = true;
                        return;
                    }

                    else if (Hit.transform.gameObject.CompareTag("pipePlace3") && pipe3Held == true)
                    {
                        pipe3Held = false;
                        pipeHeld = false;
                        reticleChange.objectGrabbed = false;
                        objectGrabable.Drop();
                        objectGrabable = null;
                        pipe3Rb.velocity = Vector3.zero;
                        pipe3.transform.position = new Vector3(46.662f, 0.372f, -22.748f);
                        pipe3.transform.rotation = Quaternion.Euler(0, -167.69f, 0);
                        pipe3Rb.constraints = RigidbodyConstraints.FreezeAll;
                        pipe3Done = true;
                        return;
                    }

                    else if (Hit.transform.gameObject.CompareTag("pipePlace4") && pipe4Held == true)
                    {
                        pipe4Held = false;
                        pipeHeld = false;
                        reticleChange.objectGrabbed = false;
                        objectGrabable.Drop();
                        objectGrabable = null;
                        pipe4Rb.velocity = Vector3.zero;
                        pipe4.transform.position = new Vector3(-39.449f, -1.654f, -9.547f);
                        pipe4.transform.rotation = Quaternion.Euler(0, 201.681f, 0);
                        pipe4Rb.constraints = RigidbodyConstraints.FreezeAll;
                        pipe4Done = true;
                        return;
                    }

                    else if (Hit.transform.gameObject.CompareTag("pipePlace5") && pipe5Held == true)
                    {
                        pipe5Held = false;
                        pipeHeld = false;
                        reticleChange.objectGrabbed = false;
                        objectGrabable.Drop();
                        objectGrabable = null;
                        pipe5Rb.velocity = Vector3.zero;
                        pipe5.transform.position = new Vector3(-40.165f, -2.04f, -11.462f);
                        pipe5.transform.rotation = Quaternion.Euler(0, 20.062f, 0);
                        pipe5Rb.constraints = RigidbodyConstraints.FreezeAll;
                        pipe5Done = true;
                        return;
                    }

                    else if (Hit.transform.gameObject.CompareTag("pipePlace6") && pipe6Held == true)
                    {
                        pipe6Held = false;
                        pipeHeld = false;
                        reticleChange.objectGrabbed = false;
                        objectGrabable.Drop();
                        objectGrabable = null;
                        pipe6Rb.velocity = Vector3.zero;
                        pipe6.transform.position = new Vector3(-39.553f, -2.93f, -10.029f);
                        pipe6.transform.rotation = Quaternion.Euler(-180, 20.32899f, 0);
                        pipe6Rb.constraints = RigidbodyConstraints.FreezeAll;
                        pipe6Done = true;
                        return;
                    }
                }
                else
                {
                    pipe1Held = false;
                    pipe2Held = false;
                    pipe3Held = false;
                    pipe4Held = false;
                    pipe5Held = false;
                    pipe6Held = false;
                    pipeHeld = false;
                    reticleChange.objectGrabbed = false;
                    objectGrabable.Drop();
                    objectGrabable = null;
                    return;
                }
            }

            else
            {
                reticleChange.objectGrabbed = false;
                objectGrabable.Drop();
                objectGrabable = null;
                return;
            }
        }

        if (pipe1Done == true && pipe2Done == true && pipe3Done == true && steamUsed == true && pipesDone == true)
        {
            StartCoroutine(Pipes1());
            StopCoroutine(Pipes1());
        }

        else if (pipe4Done == true && pipe5Done == true && pipe6Done == true && pipesDone2 == true)
        {
            boxRb.AddForce(transform.right * 0.5f * 10f, ForceMode.Impulse);
            boxRb.AddForce(transform.up * 0.5f * 10f, ForceMode.Impulse);
            pipesDone2 = false;
        }
    }

    private IEnumerator Pipes1()
    {
        pipesDone = false;
        fading.SetActive(true);
        controller.enabled = false;
        playerRb.velocity = Vector3.zero;
        player.transform.position = new Vector3(x, y, z);
        animator.SetBool("FadingOut", true);
        yield return new WaitForSeconds(2);
        player.transform.position = new Vector3(-34.36f, -1.743f, -37.81f);
        animator.SetBool("OutToIn", true);
        animator.SetBool("FadingIn", true);
        yield return new WaitForSeconds(2);
        controller.enabled = true;
        fading.SetActive(false);
        yield return new WaitForSeconds(0);
    }
    private IEnumerator Blimp()
    {
        pipesDone = false;
        fading.SetActive(true);
        controller.enabled = false;
        playerRb.velocity = Vector3.zero;
        animator.SetBool("FadingOut", true);
        yield return new WaitForSeconds(2);
        player.transform.position = new Vector3(-250.724f, -2.68f, 4.05f);
        animator.SetBool("OutToIn", true);
        animator.SetBool("FadingIn", true);
        yield return new WaitForSeconds(2);
        controller.enabled = true;
        fading.SetActive(false);
        yield return new WaitForSeconds(0);
    }

    private IEnumerator Hint2()
    {
        hint2Done = true;
        hint2.SetActive(true);
        yield return new WaitForSeconds(8);
        hint2.SetActive(false);
    }

    public void Hint2Yh()
    {
        StartCoroutine(Hint2());
        StopCoroutine(Hint2());
    }
}
