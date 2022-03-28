using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StylizedGunController : MonoBehaviour
{
    public float bulletVelocity = 40f;
    public GameObject bullet;
    public Transform barrelLocation;

    public void Shoot()
    {
        GameObject bulletInstance = Instantiate(bullet, barrelLocation.position, barrelLocation.rotation);
        bulletInstance.AddComponent<Rigidbody>();
        bulletInstance.GetComponent<Rigidbody>().mass = 0.5f;
        bulletInstance.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        bulletInstance.GetComponent<Rigidbody>().velocity = bulletVelocity * barrelLocation.forward;
        Destroy(bulletInstance, 2);
    }
}
