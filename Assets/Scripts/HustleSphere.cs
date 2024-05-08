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

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        UnityEditor.Handles.color = Color.red;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.up, _minRadius);
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.up, _maxRadius);
    }
#endif
}