using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _creationAreaRadius;
    [SerializeField] private ChapterSettings _chapterSettings;

    private List<Enemy> _enemyList = new List<Enemy>();

    public void StartNewWave(int wave)
    {
        StopAllCoroutines();

        for (int i = 0; i < _chapterSettings.EnemyWavesArray.Length; i++)
        {
            if (_chapterSettings.EnemyWavesArray[i].SpawnRatesPerSecond[wave] > 0)
            {
                StartCoroutine(CreateEnemyPerSecond(_chapterSettings.EnemyWavesArray[i].Enemy,
                                                    _chapterSettings.EnemyWavesArray[i].SpawnRatesPerSecond[wave]));

            }
        }
    }

    private IEnumerator CreateEnemyPerSecond(Enemy enemy, float enemyPerSecondRate)
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f / enemyPerSecondRate);
            Create(enemy);
        }
    }

    private void Create(Enemy enemy)
    {
        Vector2 randomPoint = Random.insideUnitCircle.normalized;
        Vector3 position = new Vector3(randomPoint.x, 0.0f, randomPoint.y) * _creationAreaRadius + _playerTransform.position;
        Enemy newEnemy = Instantiate(enemy, position, Quaternion.identity);
        newEnemy.Init(_playerTransform, this);
        _enemyList.Add(newEnemy);
    }

    public Enemy[] GetNearestEnemies(Vector3 point, int number)
    {
        List<Enemy> enemiesNearby = _enemyList.OrderBy(x => Vector3.Distance(point, x.transform.position)).ToList();
        int numberToReturn = Mathf.Min(number, enemiesNearby.Count);

        Enemy[] nearbyEnemiesArray = new Enemy[numberToReturn];
        for (int i = 0; i < numberToReturn; i++)
        {
            nearbyEnemiesArray[i] = enemiesNearby[i];
        }

        return nearbyEnemiesArray;
    }

    public void RemoveFromList(Enemy enemy)
    {
        _enemyList.Remove(enemy);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        UnityEditor.Handles.color = Color.blue;
        UnityEditor.Handles.DrawWireDisc(_playerTransform.position, Vector3.up, _creationAreaRadius);
    }
#endif
}