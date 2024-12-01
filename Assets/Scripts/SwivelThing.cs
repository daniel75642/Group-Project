using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwivelThing : MonoBehaviour
{
    public float originalx;
    public float originaly;
    public float originalz;
    public float x;
    public float y;
    public float z;

    public GameObject movingPlatform;
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MovePlatform()
    {
        movingPlatform.transform.position = new Vector3(x, y, z);
    }

    public void IdlePlatform()
    {
        movingPlatform.transform.position = new Vector3 (originalx, originaly, originalz);
    }

    public void DoorOpen()
    {
        door.transform.position = new Vector3(0, 0, 0);
    }
}
