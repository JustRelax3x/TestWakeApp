using TMPro;
using UnityEngine;

public class GameWindow : ViewWindow
{
    [SerializeField]
    private TextMeshProUGUI _hpText;

    [SerializeField]
    private TextMeshProUGUI _pointsText;

    public void UpdateHp(int hp)
    {
        _hpText.text = hp.ToString();
    }

    public void UpdatePoints(int points)
    {
        _pointsText.text = points.ToString();
    }
}