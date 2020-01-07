using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StoreDataPrefs : IStoreData
{

    [SerializeField] private int _currentLevel;

    private Action _saveAction;
    
    public void Init(Action saveAction)
    {
        _saveAction = saveAction;
    }

    public void ResetProgress()
    {
        _currentLevel = 0;
    }

    public int GetLevel()
    {
        return _currentLevel;
    }

    public void CompleteLevel()
    {
        _currentLevel++;
    }

    public void Save()
    {
        _saveAction?.Invoke();
    }
}
