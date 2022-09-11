using UnityEngine;

[CreateAssetMenu(menuName = "Factory/FruitFactory")]
public class FruitFactory : GameObjectFactory
{
    [SerializeField]
    private Fruit _applePrefab, _bananaPrefab;

    public Fruit Get(FruitType type, Transform parent)
    {
        Fruit instance = CreateGameObjectInstance(GetFruit(type), parent);
        instance.gameObject.SetActive(false);
        return instance;
    }

    private Fruit GetFruit(FruitType type)
    {
        switch (type)
        {
            case FruitType.Apple:
                return _bananaPrefab;

            case FruitType.Banana:
                return _applePrefab;
        }
        Debug.LogError($"No config for: {type}");
        return _applePrefab;
    }
}

public enum FruitType
{
    Apple,
    Banana,
}
