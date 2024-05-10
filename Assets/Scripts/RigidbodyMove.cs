using UnityEngine;

public class RigidbodyMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _rotationDamp;

    [SerializeField] private Transform _rotationPoint;

    private bool _isMovable;
    private Vector2 _moveInput;

    public void SetMoveability(bool value)
    {
        _isMovable = value;
    }

    private void Update()
    {
        if (_isMovable)
        {
            _moveInput = _joystick.Value;
            _animator.SetBool("isRunning", _joystick.IsPressed);
        }
        else
        {
            _moveInput = Vector2.zero;
            _animator.SetBool("isRunning", false);
        }

        if (_rigidbody.velocity != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(_rigidbody.velocity, Vector3.up);
            _rotationPoint.rotation = Quaternion.Lerp(_rotationPoint.rotation, targetRotation, Time.deltaTime * _rotationDamp);
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_moveInput.x, 0.0f, _moveInput.y) * _speed;

        //if(_rigidbody.velocity != Vector3.zero)
        //{
        //    Quaternion targetRotation = Quaternion.LookRotation(_rigidbody.velocity, Vector3.up);
        //    transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _rotationDamp);
        //}
    }
}