using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{

    [SerializeField] private Player _mainPlayer;

    public Player MainPlayer => _mainPlayer;
}
