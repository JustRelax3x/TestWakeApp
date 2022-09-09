using UnityEngine;
using UnityEngine.Events;

public class GameView : MonoBehaviour
{
    [SerializeField]
    private MenuWindow _menuWindow;

    [SerializeField]
    private GameWindow _gameWindow;

    [SerializeField]
    private GameOverWindow _gameOverWindow;

    private ViewWindow _currentWindow;

    public void OpenMenu(int playerHighscore, UnityAction unityAction = null)
    {
        _currentWindow?.Close();
        _menuWindow.Open();
        _currentWindow = _menuWindow;
        _menuWindow.UpdateHighScore(playerHighscore);
        _menuWindow.AddListenerPlayButton(unityAction);
        _menuWindow.AddListenerPlayButton(OpenGameWindow);
    }

    public void ShowResults(int points, int highscore, UnityAction restart, UnityAction menu)
    {
        _currentWindow.Close();
        _currentWindow = _gameOverWindow;
        _gameOverWindow.SetResults(points, highscore);
        _gameOverWindow.Open();
        _gameOverWindow.AddListenerRestartButton(OpenGameWindow);
        _gameOverWindow.AddListenerRestartButton(restart);
        _gameOverWindow.AddListenerMenuButton(menu);
    }

    public void UpdateGameStats(int points, int hp)
    {
        UpdatePoints(points);
        UpdateHp(hp);
    }

    public void UpdateHp(int hp)
    {
        _gameWindow.UpdateHp(hp);
    }

    public void UpdatePoints(int points)
    {
        _gameWindow.UpdatePoints(points);
    }

    private void OpenGameWindow()
    {
        _currentWindow.Close();
        _gameWindow.Open();
        _currentWindow = _gameWindow;
    }
}