using System.Collections.Generic;
using UnityEngine;

public class GameBehaviorSpawner : MonoBehaviour
{
    [SerializeField]
    private EnemyFactory _enemyFactory;

    [SerializeField]
    private FruitFactory _fruitFactory;

    [SerializeField]
    private Transform _parent;

    private readonly List<Enemy> _activeEnemies = new List<Enemy>();
    private readonly List<Fruit> _activeFruits = new List<Fruit>();

    private IMovePosHandler _moveHandler;

    public void SpawnEnemies(SpawnData spawnData, IMovePosHandler moveHandler, GameBehaviorCollection behaviorCollection)
    {
        _moveHandler = moveHandler;
        while (spawnData.HasNextEnemy())
        {
            Enemy enemy = SpawnEnemy(spawnData.NextEnemy());
            behaviorCollection.Add(enemy);
            _activeEnemies.Add(enemy);
        }
    }

    public void SpawnFruits(SpawnData spawnData, IMovePosHandler moveHandler)
    {
        _moveHandler = moveHandler;
        while (spawnData.HasNextFruit())
        {
            _activeFruits.Add(SpawnFruit(spawnData.NextFruit()));
        }
    }

    public void Restart()
    {
        foreach (var enemy in _activeEnemies) enemy.transform.position = _enemyFactory.SpawnPosition;
    }

    public void Clear()
    {
        foreach (var enemy in _activeEnemies) Destroy(enemy.gameObject);
        foreach (var fruit in _activeFruits) Destroy(fruit.gameObject);
        _activeEnemies.Clear();
    }

    private void FruitCollected(Fruit fruit)
    {
        fruit.UpdateMovePoint(_moveHandler.GetRandomPosition());
    }

    private Enemy SpawnEnemy(EnemyType enemyType)
    {
        Enemy enemy = _enemyFactory.Get(enemyType, _parent);
        enemy.Initialize(_moveHandler);
        enemy.gameObject.SetActive(true);
        return enemy;
    }

    private Fruit SpawnFruit(FruitType fruitType)
    {
        Fruit fruit = _fruitFactory.Get(fruitType, _parent);
        fruit.Initialize(_moveHandler);
        fruit.UpdateMovePoint(_moveHandler.GetRandomPosition());
        fruit.Collected += FruitCollected;
        fruit.gameObject.SetActive(true);
        return fruit;
    }
}