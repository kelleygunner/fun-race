using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public event System.Action OnResultShow;
    
    [SerializeField] private CameraController _cameraController;

    private Player _player;
    
    public void InitLevel(LevelData levelData)
    {
        _player = levelData.MainPlayer;
        _cameraController.UpdateCameraTarget(_player.transform);
        EnterTrigger.OnFinishReached += OnRoundFinish;
    }

    private void OnRoundFinish()
    {
        EnterTrigger.OnFinishReached -= OnRoundFinish;
        StartCoroutine(ShowResult());
    }

    public void StartRound()
    {
        _player.IsControled = true;
    }

    IEnumerator ShowResult()
    {
        yield return new WaitForSeconds(1);
        OnResultShow?.Invoke();
    }
}
