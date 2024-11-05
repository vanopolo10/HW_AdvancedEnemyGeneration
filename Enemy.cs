using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    
    private void OnDisable()
    {
        StopAllCoroutines();
    }
    
    public void StartMovingTo(GameObject gameObject)
    {
        StopAllCoroutines();
        StartCoroutine(MoveTo(gameObject));
    }

    private IEnumerator MoveTo(GameObject gameObject)
    {
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, gameObject.transform.position, _speed * Time.deltaTime);
            yield return null;
        }
    }
}