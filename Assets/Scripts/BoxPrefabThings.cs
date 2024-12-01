using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPrefabThings : MonoBehaviour
{

    private Rigidbody boxRb;

    // Start is called before the first frame update
    void Start()
    {
        boxRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("water"))
        {
            boxRb.velocity = new Vector3(0, 0, 1f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("boxLimit"))
        {
            Destroy(gameObject);
        }
    }
}
