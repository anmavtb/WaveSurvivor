using UnityEngine;

[System.Serializable]
public class Stat
{
    private float value;
    private float min;
    private float max;

    public float Value => value;
    public float Min => min;
    public float Max => max;

    public Stat(float _value, float _min, float _max)
    {
        min = _min;
        max = _max;
        value = Mathf.Clamp(_value, min, max);
    }
}