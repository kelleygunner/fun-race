using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProvider
{
    private GamePassport _gamePassport;
    
    public LevelProvider(GamePassport passport)
    {
        _gamePassport = passport;
    }

    public LevelData GetLevel()
    {
        Debug.Log($"Resources/Levels/level_{_gamePassport.GetLevel()}");
        var levelData = Resources.Load<LevelData>($"Levels/level_{_gamePassport.GetLevel()}");
        return levelData;
    }
}
