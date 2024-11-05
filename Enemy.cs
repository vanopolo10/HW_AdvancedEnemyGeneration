using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    
    private void OnDisable()
    {
        StopAllCoroutines();
    }
    
    public void StartMovingTo(Transform targetTransform)
    {
        StopAllCoroutines();
        StartCoroutine(MoveTo(targetTransform));
    }

    private IEnumerator MoveTo(Transform targetTransform)
    {
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, _speed * Time.deltaTime);
            yield return null;
        }
    }
}