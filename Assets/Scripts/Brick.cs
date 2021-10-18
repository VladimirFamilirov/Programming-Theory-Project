using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 class Brick : DestroyableObj    // INHERITANCE
{
    public GameObject brickPrefab;
    private Vector3 newBrickOne;
    private Vector3 newBrickTwo;
    
    public override void DestroyObj()   // POLYMORPHISM
    {
        newBrickOne.z = gameObject.transform.localScale.z / Random.Range(2,3);
        newBrickTwo.z = gameObject.transform.localScale.z - newBrickOne.z;
        GameObject gameObject1 = Instantiate(brickPrefab, gameObject.transform.position, gameObject.transform.rotation);
        GameObject gameObject2 = Instantiate(brickPrefab, gameObject.transform.position, gameObject.transform.rotation);
        gameObject1.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, newBrickOne.z);
        gameObject2.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, newBrickTwo.z);
        Destroy(gameObject);
    }
}
