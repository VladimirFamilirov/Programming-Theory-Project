using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 class Gem : DestroyableObj        // INHERITANCE
{
    public  override void DestroyObj()      // POLYMORPHISM
    {
        Destroy(gameObject);
    }
}
