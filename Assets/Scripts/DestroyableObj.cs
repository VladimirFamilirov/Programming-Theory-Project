using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class DestroyableObj : MonoBehaviour   // ABSTRACTION
{
    public abstract void DestroyObj();
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile" && !gameObject.name.Contains("Clone"))
        {
            DestroyObj();
        }
        else if (collision.gameObject.tag == "Projectile")
        {
            Destroy(gameObject);
        }
    }

}
