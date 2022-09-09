using UnityEngine;

internal class PlayerInput
{
    private Touch _touch;
    private Vector3 _touchPos;
    private PlayerModel _playerModel;

    public PlayerInput(PlayerModel playerModel)
    {
        _playerModel = playerModel;
    }

    public void GameUpdate()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Began)
            {
                _touchPos = Camera.main.ScreenToWorldPoint(_touch.position);
                _playerModel.UpdateMovePoint(_touchPos);
            }
        }
    }
}