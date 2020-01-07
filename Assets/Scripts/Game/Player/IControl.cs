using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IControl
{
    event System.Action OnStart;
    event System.Action OnStop;
}
