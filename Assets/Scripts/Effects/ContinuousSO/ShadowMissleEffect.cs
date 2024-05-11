using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(ShadowMissleEffect), menuName = "Effect/ContinuousEffect/" + nameof(ShadowMissleEffect))]
public class ShadowMissleEffect : ContinuousEffect
{
    [Space(10)]
    [SerializeField] private ShadowMissle _shadowMissleFrefab;
    [SerializeField] private float _projectileSpeed;

    protected override void Produce()
    {
        base.Produce();

        Transform playerTransform = _player.transform;
        int projectiles = 5;

        for (int i = 0; i < projectiles; i++)
        {
            float angle = (360.0f / projectiles) * i;
            Vector3 direction = Quaternion.Euler(0, angle, 0) * playerTransform.forward;
            ShadowMissle newProjectile = Instantiate(_shadowMissleFrefab, playerTransform.position, Quaternion.identity);
            newProjectile.Setup(direction * _projectileSpeed, damage: 20, passCount: 2);
        }
    }
}