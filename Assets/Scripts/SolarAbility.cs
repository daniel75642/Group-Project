using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;

public class SolarAbility : MonoBehaviour
{
    //Floats

    public float solarRange;

    //Animation

    public Animator animator;

    //Keybinds

    KeyCode activateAbility = KeyCode.F;
    KeyCode deactivateAbility = KeyCode.G;

    KeyCode useAbility = KeyCode.Mouse0;
    KeyCode cancelAbility = KeyCode.Mouse1;

    //Game Objects

    public GameObject solarPlatform;
    public GameObject leftClick;
    public GameObject rightClick;
    public Collider solarPlatformCollider;

    //LayerMasks

    public LayerMask solarPlaceable;

    //Mesh Renderer

    public MeshRenderer solarRenderer;


    // Start is called before the first frame update
    void Start()
    {
        solarPlatformCollider.enabled = false;
        leftClick.SetActive(false);
        rightClick.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Solar Ability Use / Cancel

        bool solarPlacingBool = animator.GetBool("solarPlacing");
        bool solarPlacedBool = animator.GetBool("solarPlaced");

        if (Input.GetKey(activateAbility) && solarPlacingBool == false && solarPlacedBool == false)
        {
            solarRenderer.enabled = true;
            SolarPlacing();
            leftClick.SetActive(true);
            rightClick.SetActive(true);
        }

        if (solarPlacingBool == true && solarPlacedBool == false)
        {
            solarRenderer.enabled = true;
            ChooseSolarPlace();
        }

        if(Input.GetKey(cancelAbility) && solarPlacingBool == true && solarPlacedBool == false)
        {
            solarRenderer.enabled = false;
            SolarCancel();
            leftClick.SetActive(false);
            rightClick.SetActive(false);
        }

        if (Input.GetKey(useAbility) && solarPlacingBool == true && solarPlacedBool == false)
        {
            solarRenderer.enabled = true;
            solarPlatformCollider.enabled = true;
            SolarPlaced();
            leftClick.SetActive(false);
            rightClick.SetActive(false);

        }

        if (Input.GetKey(deactivateAbility) && solarPlacingBool == true && solarPlacedBool == true)
        {
            solarRenderer.enabled = false;
            solarPlatformCollider.enabled = false;
            BreakSolar();
        }
    }
    private void SolarPlacing()
    {
        animator.SetTrigger("solarPlacing");
    }

    private void ChooseSolarPlace()
    {                                                                                                                                                                                                                                                                                                                                   
        RaycastHit hit;      
        if (Physics.Raycast(transform.position, transform.forward, out hit, solarRange, solarPlaceable))
        {
            solarPlatform.transform.position = hit.point + new Vector3(0, 0, 0);

            if (hit.transform.gameObject.CompareTag("forwardWallPlaceable"))
            {
                solarPlatform.transform.rotation = Quaternion.Euler(-90, 0, 0);
            }
            else if (hit.transform.gameObject.CompareTag("rightWallPlaceable"))
            {
                solarPlatform.transform.rotation = Quaternion.Euler(0, 13f, 90);
            }
            else if (hit.transform.gameObject.CompareTag("floorPlaceable"))
            {
                solarPlatform.transform.rotation = Quaternion.Euler(0, 0, 0);
            }

        }
    }

    private void SolarPlaced()
    {
        animator.SetTrigger("solarPlaced");
    }

    private void SolarCancel()
    {
        animator.SetTrigger("solarCancel");
    }

    private void BreakSolar()
    {
        animator.ResetTrigger("solarPlacing");
        animator.ResetTrigger("solarPlaced");
        animator.ResetTrigger("solarCancel");
        animator.SetTrigger("solarBreak");
    }
}
