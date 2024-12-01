using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class VineSwing : MonoBehaviour
{

    public float jumpBoost;

    public GameObject player;
    public GameObject vine;

    public Collider vineCollider;
    public Collider boxCollider;

    public Rigidbody playerRb;

    KeyCode exitVine = KeyCode.Space;

    public Behaviour stopPlayer;

    public GameObject spaceBar;

    public float x;
    public float y;
    public float z;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            stopPlayer.enabled = false;
            playerRb.velocity = Vector3.zero;
            playerRb.mass = 0;
            playerRb.useGravity = false;
            player.transform.parent = vine.transform;
            spaceBar.SetActive(true);
        }

    }

    private void OnTriggerStay(Collider other)
    {

        if (Input.GetKey(exitVine))
        {
            vineCollider.enabled = false;
            transform.DetachChildren();
            stopPlayer.enabled = true;
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
            playerRb.mass = 4;
            playerRb.useGravity = true;
            Vector3 test = new Vector3(x, y, z);
            playerRb.AddForce(10f * jumpBoost * test, ForceMode.Impulse);
            //playerRb.AddForce(10f * jumpBoost * transform.up, ForceMode.Impulse);
            spaceBar.SetActive(false);
            StartCoroutine(colliderReset());
            StopCoroutine(colliderReset());
            
        }
    }

    IEnumerator colliderReset()
    {
        yield return new WaitForSeconds(2f);
        vineCollider.enabled = true;
    }

}
