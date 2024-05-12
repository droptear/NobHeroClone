using UnityEngine;

public class ShadowMissle : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Collider _collider;
    [SerializeField] private ParticleSystem _particles;

    private float _damage;
    private int _passCount;

    void Start()
    {
        Destroy(gameObject, 5.0f);
    }

    public void Setup(Vector3 velocity, float damage, int passCount)
    {
        transform.rotation = Quaternion.LookRotation(velocity);
        _damage = damage;
        _rigidbody.velocity = velocity;
        _passCount = passCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() is Enemy enemy)
        {
            enemy.ApplyDamage(_damage);
            _passCount--;
            if(_passCount == 0)
            {
                Die();
            }
            
        }
    }

    private void Die()
    {
        _rigidbody.velocity = Vector3.zero;
        _collider.enabled = false;
        _particles.Stop();
        Destroy(gameObject, 2.0f);
    }
}