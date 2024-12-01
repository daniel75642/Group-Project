using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateSteam : MonoBehaviour
{
    public GameObject thing;
    public GameObject ladderClimb;

    public float x;
    public float y;
    public float z;

    public float originalx;
    public float originaly;
    public float originalz;

    public float laderx;
    public float ladery;
    public float laderz;

    public float originalLaderx;
    public float originalLadery;
    public float originalLaderz;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        thing.transform.position = new Vector3(originalx, originaly, originalz);
        ladderClimb.transform.position = new Vector3(originalLaderx, originalLadery, originalLaderz);
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
            thing.transform.position = new Vector3(x, y, z);
            ladderClimb.transform.position = new Vector3(laderx, ladery, laderz);

        }

        else if (collision.gameObject.CompareTag("box"))
        {
            animator.SetBool("ifBox", true);
            thing.transform.position = new Vector3(x, y, z);
            ladderClimb.transform.position = new Vector3(laderx, ladery, laderz);
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        animator.SetBool("ifPlayer", false);
        animator.SetBool("ifBox", false);
        thing.transform.position = new Vector3(originalx, originaly, originalz);
        ladderClimb.transform.position = new Vector3(originalLaderx, originalLadery, originalLaderz);
    }
}
