using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private Vector3 _moveDirection;

    public void SetDirection(Vector3 direction)
    {
        _moveDirection = direction.normalized;
    }

    private void Update()
    {
        transform.position += _moveDirection * _speed * Time.deltaTime;
    }
}
