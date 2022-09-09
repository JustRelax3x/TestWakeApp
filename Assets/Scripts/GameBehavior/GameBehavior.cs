using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class GameBehavior : MonoBehaviour
{
    [SerializeField]
    protected BehaviorData _behaviorData;

    protected float _speed;
    protected Vector3 _positionTo;
    protected IMovePosHandler _moveHandler;
    protected bool _canMove = false;

    public void Initialize(IMovePosHandler moveHandler)
    {
        _moveHandler = moveHandler;
        _positionTo = transform.position;
        _speed = _behaviorData.GetSpeed();
    }

    public virtual void GameUpdate()
    { }

    public virtual void UpdateMovePoint(Vector3 targetPos)
    {
        _positionTo = _moveHandler.ClosestPosition(targetPos);
        _positionTo.z = transform.position.z;
        _canMove = true;
    }
}