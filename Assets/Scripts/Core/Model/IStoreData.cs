using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStoreData
{
    int GetLevel();
    void CompleteLevel();

    void Save();

    void Init(Action saveAction);

    void ResetProgress();
}

