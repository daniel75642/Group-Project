using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamSwivelThing : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartCrane()
    {
        animator.SetBool("craneStart", true);
    }
}
