using UnityEngine;

public interface IMovePosHandler
{
    public Vector3 GetRandomPosition();

    public Vector3 ClosestPosition(Vector3 position);
}