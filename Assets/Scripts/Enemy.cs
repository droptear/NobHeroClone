using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _minSpeed = 1.8f;
    [SerializeField] private float _maxSpeed = 3.0f;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _rotationDamp;
    [SerializeField] private float _attackPeriod = 1.0f;
    [SerializeField] private float _damagePerSecond;

    private float _speed;
    private float _attackTimer;
    private PlayerHealth _playerHealth;

    void Start()
    {
        _speed = Random.Range(_minSpeed, _maxSpeed);
    }

    private void Update()
    {
        if (_playerHealth)
        {
            _attackTimer += Time.deltaTime;
            if(_attackTimer > _attackPeriod)
            {
                _playerHealth.TakeDamage(_damagePerSecond * _attackPeriod);
                _attackTimer = 0.0f;
            }
        }
    }

    private void FixedUpdate()
    {
        if (_playerTransform)
        {
            Vector3 towardPlayer = _playerTransform.position - transform.position;
            Quaternion towardPlayerRotation = Quaternion.LookRotation(towardPlayer, Vector3.up);

            transform.rotation = Quaternion.Lerp(transform.rotation, towardPlayerRotation, Time.deltaTime * _rotationDamp);
            _rigidbody.velocity = transform.forward * _speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerHealth>() is PlayerHealth playerHealth)
        {
            _playerHealth = playerHealth;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            _playerHealth = null;
        }
    }
}
