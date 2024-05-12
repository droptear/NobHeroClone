using System.Collections;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    [SerializeField] private ParticleSystem _rayParticles;
    [SerializeField] private ParticleSystem _bodyParticles;
    [SerializeField] private float _timeBeforeCollapse;
    [SerializeField] private float _collapseTime;

    private void Start()
    {
        StartCoroutine(LifeCycle());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() is Enemy enemy)
        {
            _rayParticles.Play();
            other.attachedRigidbody.constraints = RigidbodyConstraints.None;
            other.GetComponent<Enemy>().enabled = false;
            enemy.RemoveFromList();
            Destroy(other.gameObject, 1.5f);
        }
    }

    private IEnumerator LifeCycle()
    {
        yield return new WaitForSecondsRealtime(3.5f);
        for (float t = 0; t < _collapseTime; t += Time.unscaledDeltaTime)
        {
            Vector3 currentScale = _bodyParticles.transform.localScale;
            Vector3 targetScale = Vector3.zero;
            _bodyParticles.transform.localScale = Vector3.Lerp(currentScale, targetScale, t / _collapseTime);
            yield return null;
        }
        Destroy(gameObject);
    }
}