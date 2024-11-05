using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnSystem : MonoBehaviour
{
    [SerializeField] private List<MeshRenderer> _spawners;
    [SerializeField] private List<Target> _targets;
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private float _spawnDelay = 2f;

    private int _spawnersCount;

    private void Awake()
    {
        _spawnersCount = _spawners.Count;
    }

    private void Start()
    {
        StartCoroutine(Spawn(_spawnDelay));
    }

    private IEnumerator Spawn(float time)
    {
        WaitForSeconds spawnDelay = new WaitForSeconds(time);
        
        int spawnHeightCoefficient = 2;
        
        while (true)
        {
            MeshRenderer spawner = GetRandomSpawner(out int spawnerIndex);
            Enemy enemyPrefab = _enemies[spawnerIndex];
            Enemy enemy = Instantiate(enemyPrefab);
            
            Vector3 spawnPosition = GetHighestSurfaceCenter(spawner) + new Vector3(0, enemy.transform.localScale.y / spawnHeightCoefficient, 0);
            enemy.transform.position = spawnPosition;

            Vector3 targetPosition = _targets[spawnerIndex].transform.position;
            Vector3 enemyPosition = enemy.transform.position;

            Vector3 direction = (targetPosition - enemyPosition).normalized;
            enemy.StartMoving(direction);

            yield return spawnDelay;
        }
    }

    private MeshRenderer GetRandomSpawner(out int spawnerIndex)
    {
        spawnerIndex = Random.Range(0, _spawnersCount);
        return _spawners[spawnerIndex];
    }
    
    private Vector3 GetHighestSurfaceCenter(MeshRenderer meshRenderer)
    {
        Bounds bounds = meshRenderer.bounds;
        return new Vector3(bounds.center.x, bounds.max.y, bounds.center.z);
    }
}
