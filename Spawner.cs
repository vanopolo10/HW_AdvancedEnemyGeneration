using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private Target _target;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _spawnDelay = 2f;

    private MeshRenderer _meshRenderer;
    private Vector3 _highestSurfaceCenter;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _highestSurfaceCenter = GetHighestSurfaceCenter(_meshRenderer);
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
            Enemy enemy = Instantiate(_enemy);
            
            Vector3 spawnPosition = _highestSurfaceCenter + new Vector3(0, enemy.transform.localScale.y / spawnHeightCoefficient, 0);
            enemy.transform.position = spawnPosition;
            
            enemy.StartMovingTo(_target.transform);

            yield return spawnDelay;
        }
    }
    
    private Vector3 GetHighestSurfaceCenter(MeshRenderer meshRenderer)
    {
        Bounds bounds = meshRenderer.bounds;
        return new Vector3(bounds.center.x, bounds.max.y, bounds.center.z);
    }
}
