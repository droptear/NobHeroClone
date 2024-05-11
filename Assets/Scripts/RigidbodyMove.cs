using System.Collections;
using UnityEngine;

public class RigidbodyMove : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _rotationPoint;
    [SerializeField] private float _rotationDamp;

    private bool _isMovable;
    private Vector2 _moveInput;
    private PlayerHealth _playerHealth;
    private Rigidbody _rigidbody;
    private SphereCollider _collider;

    public void Init(PlayerHealth playerHealth)
    {
        _playerHealth = playerHealth;
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<SphereCollider>();

        _playerHealth.OnDie += OnPlayerDie;
        _rigidbody.isKinematic = false;
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
        if(_rigidbody.isKinematic == false)
        {
            _rigidbody.velocity = new Vector3(_moveInput.x, 0.0f, _moveInput.y) * _speed;
        }
    }

    private void OnDisable()
    {
        _playerHealth.OnDie -= OnPlayerDie;    
    }

    public void SetMoveability(bool value)
    {
        _isMovable = value;
    }

    private void OnPlayerDie()
    {
        _animator.SetTrigger("Die");
        StartCoroutine(ColliderExpanse(expansionMultiplier: 2.6f, expansionTime: 1.2f));
    }

    private IEnumerator ColliderExpanse(float expansionMultiplier, float expansionTime)
    {
        float currentRadius = _collider.radius;
        float expandedRadius = currentRadius * expansionMultiplier;
        for (float t = 0; t < expansionTime; t += Time.deltaTime)
        {
            _collider.radius = Mathf.Lerp(currentRadius, expandedRadius, t / expansionTime);
            yield return null;
        }
        _collider.radius = expandedRadius;
        _rigidbody.isKinematic = true;
    }
}