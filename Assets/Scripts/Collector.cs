using UnityEngine;

public class Collector: MonoBehaviour
{
    [SerializeField] private float _pickUpDistance = 2.0f;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private ParticleSystem _levelUpPartilesPrefab;

    [SerializeField] private ExperienceManager _experienceManager;

    private void OnEnable()
    {
        _experienceManager.LevelUpEvent.AddListener(OnLevelUpVisualEffect);
        _experienceManager.EffectAddedEvent.AddListener(UnfreezePlayer);
    }

    private void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _pickUpDistance, _layerMask, QueryTriggerInteraction.Ignore);

        for (int i = 0; i < colliders.Length; i++)
        {
            if(colliders[i].GetComponent<Loot>() is Loot loot)
            {
                loot.Pick(this);
            }

        }
    }

    public void TakeExperience(int value)
    {
        _experienceManager.AddExperience(value);
    }

    private void OnLevelUpVisualEffect()
    {
        GetComponent<RigidbodyMove>().IsFreezed = true;
        Instantiate(_levelUpPartilesPrefab, transform.position, Quaternion.identity);
    }

    private void UnfreezePlayer()
    {
        GetComponent<RigidbodyMove>().IsFreezed = false;
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        UnityEditor.Handles.color = Color.yellow;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.up, _pickUpDistance);
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.right, _pickUpDistance);
    }
#endif
}