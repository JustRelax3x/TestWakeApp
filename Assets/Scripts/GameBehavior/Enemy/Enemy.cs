using UnityEngine;

public class Enemy : GameBehavior
{
    public int GetDamage() => _behaviorData.GetDamage();

    public override void GameUpdate()
    {
        if (transform.position == _positionTo)
        {
            UpdateMovePoint(_moveHandler.GetRandomPosition());
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, _positionTo, _speed * Time.deltaTime);
    }
}