using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private List<Vector3> _positions;

    private int _nextPositionIndex;
    private float _epsilon;

    private void Awake()
    {
        _nextPositionIndex = 1;
        _epsilon = 0.01f;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _positions[_nextPositionIndex]) < _epsilon)
        {
            if (_positions.IndexOf(_positions[_nextPositionIndex]) != _positions.Count - 1)
                _nextPositionIndex++;
            else
                _nextPositionIndex = 0;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, _positions[_nextPositionIndex], _speed * Time.deltaTime);
    }
}