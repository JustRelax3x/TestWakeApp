using UnityEngine;

public class PlayerModel : GameBehavior
{
    //private Vector3 _direction;
    public event System.Action<int> PlayerDamaged;

    public event System.Action<int> PlayerGotPoints;

    public override void GameUpdate()
    {
        if (!_canMove) return;
        if (transform.position == _positionTo)
        {
            _canMove = false;
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, _positionTo, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            PlayerDamaged?.Invoke(enemy.GetDamage());
        }
        else if (collision.TryGetComponent(out Fruit fruit))
        {
            PlayerGotPoints?.Invoke(fruit.Points());
        }
    }
}