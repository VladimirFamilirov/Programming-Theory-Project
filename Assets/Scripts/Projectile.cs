using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody projectileRb;

    private float projectilePower = 1200f;
    // Start is called before the first frame update
    void Start()
    {
        projectileRb = GetComponent<Rigidbody>();
        projectileRb.AddRelativeForce(Vector3.forward * projectilePower);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > 15 || (transform.position.x > 16 && transform.position.x < -16))
        {
            Destroy(gameObject);
        }
    }
}
