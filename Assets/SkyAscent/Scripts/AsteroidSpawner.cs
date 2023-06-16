using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [Header("Size of the spawner area")]
    public Vector3 spawnerSize;

    [Header("Rate of spawn")]
    public float spawnRate = 1f;

    [Header("Model to spawn")]
    [SerializeField] private GameObject asteriodModel;

    private float spawnTimer = 0f;

    private void onDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position, spawnerSize);
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if(spawnTimer > spawnRate)
        {
            spawnTimer = 0;
            spawnAsteroid();
        }
    }

    private void spawnAsteroid()
    {
        //get a random position for the asteroid
        Vector3 spawnPoint = transform.position + new Vector3(UnityEngine.Random.Range(-spawnerSize.x / 2, spawnerSize.x / 2),
                                                              UnityEngine.Random.Range(-spawnerSize.y / 2, spawnerSize.y / 2),
                                                              UnityEngine.Random.Range(-spawnerSize.z / 2, spawnerSize.z / 2));

        GameObject asteroid = Instantiate(asteriodModel, spawnPoint, transform.rotation);

        asteroid.transform.SetParent(this.transform);
    }
}
