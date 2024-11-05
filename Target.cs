using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private Vector3 _position1;
    [SerializeField] private Vector3 _position2;

    private Vector3 _positionToGo;
    private float _epsilon;

    private void Awake()
    {
        _positionToGo = _position2;
        _epsilon = 0.1f;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _position2) < _epsilon)
            _positionToGo = _position1;
        else if (Vector3.Distance(transform.position, _position1) < _epsilon)
            _positionToGo = _position2;

        transform.position = Vector3.MoveTowards(transform.position, _positionToGo, _speed * Time.deltaTime);
    }
}