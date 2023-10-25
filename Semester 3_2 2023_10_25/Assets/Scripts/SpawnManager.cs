using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private float spawnInterval;
    [SerializeField] private MoverBase enemyPrefab;
    [SerializeField] private List<SpawnPoint> spawnPoints;
    [Range(0.01f, 1.0f)]
    [SerializeField] private float intervalMultiplier = .95f;

    private void OnEnable()
    {
        StartCoroutine(SpawnEnemyCoroutine());
    }

    private IEnumerator SpawnEnemyCoroutine()
    {
        while (true)
        {
            SpawnPoint point = spawnPoints[Random.Range(0, spawnPoints.Count)];
            if (point.TrySpawnObject(enemyPrefab))
            {
                yield return new WaitForSeconds(spawnInterval);
                spawnInterval *= intervalMultiplier;
            }
            
            yield return null;
        }
    }
}
