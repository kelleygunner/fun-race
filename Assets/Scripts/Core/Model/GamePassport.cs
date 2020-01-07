using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePassport
{
    private IStoreData _storeData;

    public GamePassport(IStoreData storeData)
    {
        _storeData = storeData;
    }

    public int GetLevel()
    {
        return _storeData.GetLevel();
    }

    public void CompleteLevel()
    {
        _storeData.CompleteLevel();
        _storeData.Save();
    }

    public void ResetProgress()
    {
        _storeData.ResetProgress();
        _storeData.Save();
    }
}
