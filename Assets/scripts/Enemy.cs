using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private Vector3 _directional;

    private void Update()
    {
        transform.Translate(_directional * _speed * Time.deltaTime);
    }

    public void AssignDirectional(Vector3 directional)
    {
        _directional = directional.normalized;
    }
}
