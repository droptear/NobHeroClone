using System;
using UnityEngine;

[Serializable]
public struct EnemyWaveSpawnRate
{
    public Enemy Enemy;
    public float[] SpawnRatesPerSecond;
}

[CreateAssetMenu]
public class ChapterSettings : ScriptableObject
{
    public EnemyWaveSpawnRate[] EnemyWavesArray;
}