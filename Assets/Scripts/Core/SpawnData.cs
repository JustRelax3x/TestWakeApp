using UnityEngine;

[CreateAssetMenu(menuName = "GameData/SpawnData")]
public class SpawnData : ScriptableObject
{
    [SerializeField]
    private EnemyType[] _enemiesToSpawn;

    [SerializeField]
    private FruitType[] _fruitsToSpawn;

    private int _counterEnemies = 0, _counterFruits = 0;

    public void Reset()
    {
        _counterEnemies = 0;
        _counterFruits = 0;
    }

    public bool HasNextEnemy() => _counterEnemies < _enemiesToSpawn.Length;

    public bool HasNextFruit() => _counterFruits < _fruitsToSpawn.Length;

    public EnemyType NextEnemy()
    {
        if (HasNextEnemy())
            return _enemiesToSpawn[_counterEnemies++];
        return EnemyType.Circle;
    }

    public FruitType NextFruit()
    {
        if (HasNextFruit())
            return _fruitsToSpawn[_counterFruits++];
        return FruitType.Apple;
    }
}