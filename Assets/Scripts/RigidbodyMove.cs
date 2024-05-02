using UnityEngine;

public class RigidbodyMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _rotationDamp;

    private Vector2 _moveInput;

    void Update()
    {
        _moveInput = _joystick.Value;

        _animator.SetBool("isRunning", _joystick.IsPressed);
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_moveInput.x, 0.0f, _moveInput.y) * _speed;

        if(_rigidbody.velocity != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(_rigidbody.velocity, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _rotationDamp);
        }
    }
}