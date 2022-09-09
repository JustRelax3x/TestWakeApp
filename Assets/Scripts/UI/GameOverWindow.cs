using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameOverWindow : ViewWindow
{
    [SerializeField]
    private TextMeshProUGUI _pointsText;

    [SerializeField]
    private TextMeshProUGUI _highscoreText;

    [SerializeField]
    private Button _restart;

    [SerializeField]
    private Button _menu;

    public void SetResults(int points, int highscore)
    {
        _pointsText.text = points.ToString();
        _highscoreText.text = highscore.ToString();
    }

    public void AddListenerMenuButton(UnityAction unityAction)
    {
        _menu.onClick.AddListener(unityAction);
    }

    public void AddListenerRestartButton(UnityAction unityAction)
    {
        _restart.onClick.AddListener(unityAction);
    }

    public override void Close()
    {
        _menu.onClick.RemoveAllListeners();
        _menu.onClick.RemoveAllListeners();
        base.Close();
    }
}