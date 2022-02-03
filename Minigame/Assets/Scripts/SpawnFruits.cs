using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFruits : MonoBehaviour
{
    public float spawnFruitsSpeed;

    [Header("SpawnPoints")]
    public GameObject[] spawnPoints;

    [Header("Fruits")]
    public GameObject[] fruits;

    private void Start()
    {
        StartCoroutine(SpawnFruitsCoroutine());
    }

    IEnumerator SpawnFruitsCoroutine()
    {
        while (true)
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if (Random.Range(0, 4) == 0)
                {
                    Instantiate(fruits[0], spawnPoints[i].transform.position, spawnPoints[i].transform.rotation);
                    Debug.Log(fruits[0].name + "Spawned");
                }
            }
            yield return new WaitForSeconds(spawnFruitsSpeed);
        }
    }
}
