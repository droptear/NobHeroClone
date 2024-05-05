using UnityEngine;

public class Collector: MonoBehaviour
{
    [SerializeField] private float _pickUpDistance = 2.0f;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private ParticleSystem _levelUpPartilesPrefab;
    [SerializeField] private ExperienceManager _experienceManager;

    private RigidbodyMove _rigidbodyMove;

    private void OnEnable()
    {
        _experienceManager.LevelUpEvent.AddListener(OnLevelUp);
        _experienceManager.EffectAddedEvent.AddListener(OnEffectAdded);
    }

    private void Start()
    {
        _rigidbodyMove = GetComponent<RigidbodyMove>();
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

    private void OnLevelUp()
    {
        _rigidbodyMove.SetMoveability(false);
        Instantiate(_levelUpPartilesPrefab, transform.position, Quaternion.identity);
    }

    private void OnEffectAdded()
    {
        _rigidbodyMove.SetMoveability(true);
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