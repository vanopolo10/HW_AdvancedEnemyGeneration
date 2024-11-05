using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    
    private void OnDisable()
    {
        StopAllCoroutines();
    }
    
    public void StartMoving(Vector3 direction)
    {
        StopAllCoroutines();
        StartCoroutine(MoveTo(direction));
    }

    private IEnumerator MoveTo(Vector3 direction)
    {
        while (true)
        {
            transform.position += direction * (Time.deltaTime * _speed);
            yield return null;
        }
    }
}