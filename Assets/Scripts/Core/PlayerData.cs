using UnityEngine;

[CreateAssetMenu(menuName = "GameData/PlayerData")]
public class PlayerData : ScriptableObject
{
    [SerializeField]
    private int _startingHealth = 5;

    public Vector3 SpawnPoint;
    public int Highscore { get; private set; } = 0;
    public int Health { get; private set; }
    public int Points { get; private set; }

    public bool TryKill(int damage)
    {
        if (damage <= 0) return false;
        Health -= damage;
        return Health <= 0;
    }

    public void AddPoints(int points)
    {
        if (points <= 0) return;
        Points += points;
    }

    public bool TrySetHighScore(int highscore)
    {
        if (highscore <= Highscore) return false;
        Highscore = highscore;
        return true;
    }

    public void Reset()
    {
        Health = _startingHealth;
        Points = 0;
    }
}