using System.Collections.Generic;

public class GameBehaviorCollection
{
    private List<GameBehavior> _behaviors = new List<GameBehavior>();
    public bool IsEmpty => _behaviors.Count == 0;

    public int Length => _behaviors.Count;

    public void Add(GameBehavior behavior)
    {
        _behaviors.Add(behavior);
    }

    public void GameUpdate()
    {
        for (int i = 0; i < Length; i++)
        {
            _behaviors[i].GameUpdate();
        }
    }

    public void Clear()
    {
        _behaviors.Clear();
    }
}