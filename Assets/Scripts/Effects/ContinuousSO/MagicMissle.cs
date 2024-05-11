using UnityEngine;

public class MagicMissle : MonoBehaviour
{
    [SerializeField] private float _maxLifespan = 4.0f;
    private Enemy _target;
    private float _projectileSpeed;
    private float _damage;

    public void Setup(Enemy target, float damage, float speed)
    {
        _target = target;
        _projectileSpeed = speed;
        _damage = damage;

        Destroy(gameObject, _maxLifespan);
    }

    private void Update()
    {
        if (_target)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, Time.deltaTime * _projectileSpeed);
            if(transform.position == _target.transform.position)
            {
                AffectEnemy();
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void AffectEnemy()
    {
        _target.ApplyDamage(_damage);
    }
}