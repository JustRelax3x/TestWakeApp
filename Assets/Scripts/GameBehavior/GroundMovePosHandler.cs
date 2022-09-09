using UnityEngine;

public class GroundMovePosHandler : IMovePosHandler
{
    private Collider2D _playGround;

    public GroundMovePosHandler(Collider2D playGround)
    {
        _playGround = playGround;
    }

    public Vector3 ClosestPosition(Vector3 position)
    {
        return _playGround.ClosestPoint(position);
    }

    public Vector3 GetRandomPosition()
    {
        return new Vector3(
        Random.Range(_playGround.bounds.min.x, _playGround.bounds.max.x),
        Random.Range(_playGround.bounds.min.y, _playGround.bounds.max.y), 1f);
    }
}