using UnityEngine;

[CreateAssetMenu(menuName = "GameData/BehaviorData")]
public class BehaviorData : ScriptableObject
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private int _damage;

    [SerializeField]
    private int _points;

    public float GetSpeed() => _speed;

    public int GetDamage() => _damage;

    public int GetPoints() => _points;
}