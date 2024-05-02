using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform _target;
    [SerializeField] private float _dampRate = 3.0f;
    
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _target.transform.position, Time.deltaTime * _dampRate);
    }
}