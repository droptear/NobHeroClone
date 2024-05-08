using UnityEngine;

public class HustleSphere : MonoBehaviour
{
    [SerializeField] private float _minRadius = 1.9f;
    [SerializeField] private float _maxRadius = 2.5f;

    private float _radius;
    void Start()
    {
        _radius = Random.Range(_minRadius, _maxRadius);
        transform.localScale = Vector3.one * _radius;
    }
}
