using UnityEngine;

public abstract class GameObjectFactory : ScriptableObject
{
    protected T CreateGameObjectInstance<T>(T prefab, Transform parent) where T : MonoBehaviour
    {
        T instance = Instantiate(prefab, parent);
        return instance;
    }
}