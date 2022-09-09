using UnityEngine;

public class Fruit : GameBehavior
{
    public System.Action<Fruit> Collected;

    public int Points()
    {
        Collected?.Invoke(this);
        return _behaviorData.GetPoints();
    }

    public override void UpdateMovePoint(Vector3 targetPos)
    {
        _positionTo = _moveHandler.ClosestPosition(targetPos);
        _positionTo.z = transform.position.z;
        transform.position = _positionTo;
    }
}