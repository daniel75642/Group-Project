using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class VentBlockLayer : MonoBehaviour
{
    public Transform cube;

    void Update()
    {
        transform.position = cube.position;
        transform.rotation = cube.rotation;
    }
}
