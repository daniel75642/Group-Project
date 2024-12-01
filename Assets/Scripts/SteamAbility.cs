using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamAbility : MonoBehaviour
{
    public GameObject pipe1;
    public GameObject pipe2;
    public GameObject pipe3;
    public GameObject pipe4;
    public GameObject pipe5;
    public GameObject pipe6;

    KeyCode use = KeyCode.F;
    KeyCode cancel = KeyCode.G;

    private bool active;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(use) && active == false)
        {
            pipe1.layer = 15;
            pipe2.layer = 15;
            pipe3.layer = 15;
            pipe4.layer = 15;
            pipe5.layer = 15;
            pipe6.layer = 15;
            active = true;
        }

        if (Input.GetKeyDown(cancel) && active == true)
        {
            pipe1.layer = 6;
            pipe2.layer = 6;
            pipe3.layer = 6;
            pipe4.layer = 6;
            pipe5.layer = 6;
            pipe6.layer = 6;
            active = false;
        }
    }
}
