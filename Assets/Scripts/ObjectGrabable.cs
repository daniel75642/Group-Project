using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabable : MonoBehaviour
{
    private Rigidbody objectRigidbody;
    private Collider objectCollider;

    public Transform objectGrabPointTransform;

    public float lerpSpeed;

    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
        objectCollider = GetComponent<Collider>();
    }
    public void Grab(Transform objectGrabPointTransform)
    {
        objectCollider.enabled = false;
        objectRigidbody.useGravity = false;
        objectRigidbody.mass = 0;
        objectRigidbody.isKinematic = true;
        this.objectGrabPointTransform = objectGrabPointTransform;
    }

    public void Drop()
    {
        objectCollider.enabled = true;
        objectRigidbody.useGravity = true;
        objectRigidbody.mass = 1;
        objectRigidbody.isKinematic = false;
        this.objectGrabPointTransform = null;
    }

    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position,Time.deltaTime * lerpSpeed);
            objectRigidbody.MovePosition(newPosition);
        }
    }


}
