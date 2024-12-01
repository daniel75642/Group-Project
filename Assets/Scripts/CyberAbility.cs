using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyberAbility : MonoBehaviour
{

    public GameObject laserShooter;
    private GameObject laserShooterClone;

    public Transform CamerPos;

    KeyCode place = KeyCode.F;
    KeyCode destroy = KeyCode.G;

    bool isPlaced;

    bool findObject;

    // Start is called before the first frame update
    void Start()
    {
        isPlaced = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(place) && isPlaced == false)
        {
            findObject = GameObject.Find("Lazer Shooter(Clone)");
            if (findObject == false)
            {
                isPlaced = true;
                laserShooterClone = Instantiate(laserShooter, CamerPos.position, CamerPos.rotation);
            }
        }
        
        else if(Input.GetKeyDown(destroy) && isPlaced == true)
        {
            findObject = GameObject.Find("Lazer Shooter(Clone)");
            if (findObject == true)
            {
                isPlaced = false;
                Destroy(laserShooterClone);
            }
        }
    }
}
