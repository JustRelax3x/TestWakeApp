using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MenuWindow : ViewWindow
{
    [SerializeField]
    private Button _playButton;

    [SerializeField]
    private TextMeshProUGUI _highscoreText;

    public void UpdateHighScore(int highscore)
    {
        _highscoreText.text = highscore.ToString();
    }

    public void AddListenerPlayButton(UnityAction unityAction)
    {
        _playButton.onClick.AddListener(unityAction);
    }

    public override void Close()
    {
        _playButton.onClick.RemoveAllListeners();
        base.Close();
    }
}