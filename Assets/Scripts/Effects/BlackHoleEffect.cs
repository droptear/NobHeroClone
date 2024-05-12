using UnityEngine;

[CreateAssetMenu(fileName = nameof(BlackHoleEffect), menuName = "Effects/ContinuousEffect/" + nameof(BlackHoleEffect))]
public class BlackHoleEffect : ContinuousEffect
{
    [Space(10)]
    [SerializeField] private BlackHole _blackHolePrefab;

    protected override void Produce()
    {
        base.Produce();

        Transform playerTransform = _player.transform;
        BlackHole newBlackHole = Instantiate(_blackHolePrefab, playerTransform.position + new Vector3(0.0f, 0.2f, 0.0f), Quaternion.identity);
    }
}