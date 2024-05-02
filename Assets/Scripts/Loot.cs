using System.Collections;
using UnityEngine;

public class Loot : MonoBehaviour
{
    [SerializeField] private Collider _collider;

    public void Pick(Collector collector)
    {
        _collider.enabled = false;
        StartCoroutine(MoveToCollector(collector));
    }

    private IEnumerator MoveToCollector(Collector collector)
    {
        Vector3 a = transform.position;
        Vector3 b = a + Vector3.up * 3.0f;

        for (float t = 0; t < 1.0f; t += Time.deltaTime * 3.0f)
        {
            Vector3 d = collector.transform.position;
            Vector3 c = d + Vector3.up * 3.0f;

            Vector3 position = Bezier.GetPoint(a, b, c, d, t); 
            transform.position = position;
            yield return null;
        }

        Collect(collector);

    }

    public virtual void Collect(Collector collector)
    {
        Destroy(gameObject);
    }
}