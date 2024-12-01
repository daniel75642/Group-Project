using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleChange : MonoBehaviour
{

    public Transform playerCameraTransform;

    public float interactDistance;

    public LayerMask grabableLayerMask;

    public GameManager gameManager;

    private ObjectGrabable objectGrabable;
    private SteamSwivelThing steamSwivelThing;
    private SwivelThing swivelThing;

    public bool objectGrabbed;

    public GameObject E;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit Hit, interactDistance, grabableLayerMask))
        {
            if (Hit.transform.TryGetComponent(out steamSwivelThing) && objectGrabbed == false && gameManager.AbilityChoice == false)
            {
                gameManager.HoverReticle();
                E.SetActive(true);
            }

            else if (Hit.transform.TryGetComponent(out swivelThing) && objectGrabbed == false && gameManager.AbilityChoice == false)
            {
                gameManager.HoverReticle();
                E.SetActive(true);
            }

            else if (Hit.transform.TryGetComponent(out objectGrabable) && objectGrabbed == false && gameManager.AbilityChoice == false)
            {
                gameManager.HoverReticle();
                E.SetActive(true);
            }

            else if (Hit.transform.CompareTag("blimp") && objectGrabbed == false && gameManager.AbilityChoice == false)
            {
                gameManager.HoverReticle();
                E.SetActive(true);
            }

            else if (Hit.transform.CompareTag("ladder") && objectGrabbed == false && gameManager.AbilityChoice == false)
            {
                gameManager.HoverReticle();
                E.SetActive(true);
            }

            else if (Hit.transform.CompareTag("ladder2") && objectGrabbed == false && gameManager.AbilityChoice == false)
            {
                gameManager.HoverReticle();
                E.SetActive(true);
            }

            else if (Hit.transform.CompareTag("ladder3") && objectGrabbed == false && gameManager.AbilityChoice == false)
            {
                gameManager.HoverReticle();
                E.SetActive(true);
            }
        }
        else if (objectGrabbed == true && gameManager.AbilityChoice == false)
        {
            gameManager.GrabbedReticle();
            E.SetActive(false);
        }
        else if (objectGrabbed == false && gameManager.AbilityChoice == false)
        {
            gameManager.ReticleIdle();
            E.SetActive(false);
        }
    }
}
