using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirVent : MonoBehaviour
{
    //Floats

    public float ventRange;
    public float x;
    public float y;
    public float z;
    public float originalx;
    public float originaly;
    public float originalz;

    //GameObjects

    public GameObject movableDoor;

    //Layer Masks

    public LayerMask whatIsGround;

    //Bools

    public bool keepOpen;

    //Animator

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        keepOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * ventRange);
        if (Physics.Raycast(transform.position, transform.forward, out hit, ventRange, whatIsGround))
        {
            if (hit.collider.gameObject.CompareTag("ventEnd"))
            {
                movableDoor.transform.position = new Vector3(x, y, z);
                animator.SetBool("Hit", true);
                return;
            }

            else if (keepOpen == false)
            {
                movableDoor.transform.position = new Vector3(originalx, originaly, originalz);
                animator.SetBool("Hit", false);
                return;
            }

            else if (keepOpen == true)
            {
                movableDoor.transform.position = new Vector3(x, y, z);
                animator.SetBool("Hit", false);
                return;
            }

            else
            {
                animator.SetBool("Hit", false);
                return;
            }
            
        }

    }

    public void Open()
    {
        keepOpen = true;
    }

}
