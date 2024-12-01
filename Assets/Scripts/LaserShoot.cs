using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LaserShoot : MonoBehaviour
{
    public float maxRange;

    public int reflections;

    public LayerMask Reflectable;

    private LineRenderer lr;
    private Ray ray;
    private RaycastHit hit;
    private Vector3 direction;

    private Scanner scanner;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ray = new Ray(transform.position, transform.forward);

        lr.positionCount = 1;
        lr.SetPosition(0, transform.position);
        float remainingLength = maxRange;

        for (int i = 0; i < reflections; i++)
        {

            if (Physics.Raycast(ray.origin, ray.direction, out hit, remainingLength))
            {
                lr.positionCount += 1;
                lr.SetPosition(lr.positionCount - 1, hit.point);
                remainingLength -= Vector3.Distance(ray.origin, hit.point);
                ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));

                if (hit.transform.TryGetComponent(out scanner))
                {
                    scanner.IDK();
                    break;
                }

                else if (hit.collider.tag != "mirror")
                {
                    break;
                }

            }
            else
            {
                lr.positionCount += 1;
                lr.SetPosition(lr.positionCount - 1, ray.origin + ray.direction * remainingLength);
            }
        } 
    }
}
