using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameBehaviorSpawner _behaviorSpawner;

    [SerializeField]
    private PlayerModel _playerModel;

    [SerializeField]
    private GameView _gameView;

    [SerializeField]
    private Collider2D _playGround;

    [SerializeField]
    private SpawnData _spawnData;

    [SerializeField]
    private PlayerData _playerData;

    private PlayerInput _playerInput;

    private readonly GameBehaviorCollection _behaviorCollection = new GameBehaviorCollection();

    private IMovePosHandler _moveHandler;

    private bool _pause;

    private const string _save = "Highscore";

    private void Awake()
    {
        _playerData.TrySetHighScore(PlayerPrefs.GetInt(_save, 0));
    }

    private void OnEnable()
    {
        _playerModel.PlayerDamaged += DamagePlayer;
        _playerModel.PlayerGotPoints += GotPoints;
        _gameView.OpenMenu(_playerData.Highscore, StartGame);
        _pause = true;
    }

    private void OnDisable()
    {
        _playerModel.PlayerDamaged -= DamagePlayer;
        _playerModel.PlayerGotPoints -= GotPoints;
        _behaviorSpawner.Clear();
    }

    private void Update()
    {
        if (_pause) return;
        _playerInput.GameUpdate();
        _behaviorCollection.GameUpdate();
    }

    private void DamagePlayer(int damage)
    {
        if (_playerData.TryKill(damage)) GameOver();
        else _gameView.UpdateHp(_playerData.Health);
    }

    private void GotPoints(int points)
    {
        _playerData.AddPoints(points);
        _gameView.UpdatePoints(_playerData.Points);
    }

    private void StartGame()
    {
        _moveHandler = new GroundMovePosHandler(_playGround);
        _playerInput = new PlayerInput(_playerModel);
        _playerModel.Initialize(_moveHandler);
        _behaviorCollection.Add(_playerModel);
        _spawnData.Reset();
        _behaviorSpawner.SpawnEnemies(_spawnData, _moveHandler, _behaviorCollection);
        _behaviorSpawner.SpawnFruits(_spawnData, _moveHandler);
        BeginNewGame();
        _pause = false;
    }

    private void Restart()
    {
        _behaviorSpawner.Restart();
        BeginNewGame();
    }

    public void Menu()
    {
        _gameView.OpenMenu(_playerData.Highscore, Restart);
        _pause = true;
    }

    private void BeginNewGame()
    {
        _playerModel.transform.position = _playerData.SpawnPoint;
        _playerModel.UpdateMovePoint(_playerData.SpawnPoint);
        _playerData.Reset();
        _gameView.UpdateGameStats(_playerData.Points, _playerData.Health);
        _pause = false;
    }

    private void GameOver()
    {
        if (_playerData.TrySetHighScore(_playerData.Points)) PlayerPrefs.SetInt(_save, _playerData.Highscore);
        _gameView.ShowResults(_playerData.Points, _playerData.Highscore, Restart, Menu);
        _pause = true;
    }
}