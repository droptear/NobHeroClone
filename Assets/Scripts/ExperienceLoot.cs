using UnityEngine;

public class ExperienceLoot : Loot
{
    [SerializeField] private int _experienceValue;

    public override void Collect(Collector collector)
    {
        base.Collect(collector);
        collector.TakeExperience(_experienceValue);
    }
}