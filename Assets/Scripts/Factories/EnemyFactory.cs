﻿using UnityEngine;

[CreateAssetMenu(menuName = "Factory/EnemyFactory")]
public class EnemyFactory : GameObjectFactory
{
    [SerializeField]
    private Enemy _circlePrefab, _squarePrefab;

    public Vector3 SpawnPosition;

    public Enemy Get(EnemyType type, Transform parent)
    {
        Enemy instance = CreateGameObjectInstance(GetEnemy(type), parent);
        instance.transform.position = SpawnPosition;
        instance.gameObject.SetActive(false);
        return instance;
    }

    private Enemy GetEnemy(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.Square:
                return _squarePrefab;

            case EnemyType.Circle:
                return _circlePrefab;
        }
        Debug.LogError($"No config for: {type}");
        return _circlePrefab;
    }
}

public enum EnemyType
{
    Circle,
    Square
}