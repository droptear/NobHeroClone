using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _minSpeed = 1.8f;
    [SerializeField] private float _maxSpeed = 3.0f;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _rotationDamp;
    [SerializeField] private float _attackPeriod = 1.0f;
    [SerializeField] private float _damagePerSecond;
    [SerializeField] private float _health = 50.0f;
    [SerializeField] private ParticleSystem _particles;

    private EnemyManager _enemyManager;
    private Transform _playerTransform;
    private PlayerHealth _playerHealth;
    private float _speed;
    private float _attackTimer;

    public void Init(Transform playerTransform, EnemyManager enemyManager)
    {
        _playerTransform = playerTransform;
        _enemyManager = enemyManager;
    }

    private void Start()
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

            if(towardPlayer.magnitude > 32.0f)
            {
                transform.position += towardPlayer * 1.95f;
            }
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

    public void ApplyDamage(float value)
    {
        _health -= value;
        if(_health <= 0.0f)
        {
            Die();
        }
    }

    private void Die()
    {
        _particles.Play();
        Debug.Log("Particles supposed to be played.");
        _enemyManager.RemoveFromList(this);
        Destroy(gameObject); 
    }
}