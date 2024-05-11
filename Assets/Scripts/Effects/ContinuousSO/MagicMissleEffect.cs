using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(MagicMissleEffect), menuName = "Effects/ContinuousEffect/" + nameof(MagicMissleEffect))]
public class MagicMissleEffect : ContinuousEffect
{
    [SerializeField] private MagicMissle _magicMisslePrefab;
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private float _projectileCooldownTime = 0.2f;

    protected override void Produce()
    {
        base.Produce();
        _effectsManager.StartCoroutine(FireProjectiles());
    }

    private IEnumerator FireProjectiles()
    {
        int projectiles = 4;
        Enemy[] nearestEnemies = _enemyManager.GetNearestEnemies(point: _player.transform.position, number: projectiles);
        if(nearestEnemies.Length > 0)
        {
            for (int i = 0; i < nearestEnemies.Length; i++)
            {
                Vector3 position = _player.transform.position;
                MagicMissle magicMissle = Instantiate(_magicMisslePrefab, position, Quaternion.identity);
                magicMissle.Setup(nearestEnemies[i], damage: 20.0f, speed: _projectileSpeed);
                yield return new WaitForSeconds(_projectileCooldownTime);
            }
        }
    }
}
