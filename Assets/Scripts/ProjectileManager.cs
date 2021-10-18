using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public GameObject projectilePrefab;

    private Vector3 spawnPos = new Vector3(0, 2, -24);

    private float startDelay = 2;
    private float repeatRate = 6;
    void Start()
    {
        StartCoroutine(SpawnProjectile());
    }

    void Update()
    {
        
    }


    IEnumerator SpawnProjectile()
    {
        while (GameManager.Instance.isActive)
        {
            yield return new WaitForSeconds(repeatRate);
            spawnPos = new Vector3(Random.Range(-13, 14), 1, -24);
            Instantiate(projectilePrefab, spawnPos, projectilePrefab.transform.rotation);
            GameManager.Instance.score++;
            repeatRate -= 0.3f;
        }
    }
}
