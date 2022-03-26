using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPresensePhysics : MonoBehaviour
{
    public Transform target;
    private Rigidbody _rigidBody;
    private Collider[] _handCollidors;

    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _handCollidors = GetComponentsInChildren<Collider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Update hand position
        //_rigidBody.velocity = (target.position - transform.position) / Time.fixedDeltaTime;

        // Update hand rotation
        //Quaternion rotationDifference = target.rotation * Quaternion.Inverse(transform.rotation);
        //rotationDifference.ToAngleAxis(out float angleInDegrees, out Vector3 rotationAxis);
        
        //Vector3 rotationDifferenceInDegrees = angleInDegrees * rotationAxis;
        
        //_rigidBody.angularVelocity = (rotationDifferenceInDegrees * Mathf.Deg2Rad / Time.fixedDeltaTime);
    }

    public void EnableHandCollidorDelay(float delay)
    {
        Invoke("EnableHandCollidor", delay);
    }

    public void EnableHandCollidor()
    {
        foreach(Collider mesh in _handCollidors)
        {
            mesh.enabled = true;
        }
    }

    public void DisableHandCollidor()
    {
        foreach (Collider mesh in _handCollidors)
        {
            mesh.enabled = false;
        }
    }
}
