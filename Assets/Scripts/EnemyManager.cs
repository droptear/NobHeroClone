using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _creationAreaRadius;
    [SerializeField] private ChapterSettings _chapterSettings;

    private List<Enemy> _enemyList = new List<Enemy>();

    private void Start()
    {
        StartNewWave(5);   
    }

    private void StartNewWave(int wave)
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
        newEnemy.Init(_playerTransform);
        _enemyList.Add(newEnemy);
    }

    private void Remove(Enemy enemy)
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