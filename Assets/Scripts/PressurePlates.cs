using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlates : MonoBehaviour
{
    public Animator animator;

    public GameObject box;

    public bool findObject;

    public float spawnx;
    public float spawny;
    public float spawnz;

    public float rotatex;
    public float rotatey;
    public float rotatez;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        bool ifBox = animator.GetBool("ifBox");
        bool ifPlayer = animator.GetBool("ifPlayer");

        if (collision.gameObject.CompareTag("player"))
        {
            
            animator.SetBool("ifPlayer", true);
            findObject = GameObject.Find("box(Clone)");
            if (findObject == false)
            {
                SpawnBox();
            }
        }

        else if (collision.gameObject.CompareTag("box"))
        {
            animator.SetBool("ifBox", true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        animator.SetBool("ifPlayer", false);
        animator.SetBool("ifBox", false);
    }

    private void SpawnBox()
    {
        Instantiate(box, new Vector3(spawnx, spawny, spawnz), Quaternion.Euler(rotatex, rotatey, rotatez));
    }
}
