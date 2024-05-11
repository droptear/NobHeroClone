using UnityEngine;

public class ContinuousEffect : Effect
{
    [SerializeField] private float _cooldownTime;

    private float _timer;

    public void ProcessFrame(float frameTime)
    {
        _timer += frameTime;
        if(_timer > _cooldownTime)
        {
            Produce();
            _timer = 0.0f;
        }
    }

    protected virtual void Produce()
    {

    }
}