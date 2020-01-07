using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
    [SerializeField] private UIController _uiController;

    private IStoreData _storeData;
    private GamePassport _gamePassport;

    private LevelProvider _levelProvider;

    private LevelData _currentLevel;
    
    void Start()
    {
        _storeData = GetStoreData();
        _gamePassport = new GamePassport(_storeData);
        _gamePassport.ResetProgress();
        Debug.Log($"Current Level: {_gamePassport.GetLevel()}");
        _levelProvider = new LevelProvider(_gamePassport);
        
        ShowMenu();
    }

    public void StartLevel()
    {
        _uiController.OpenUI(UIState.Game);
        _gameController.StartRound();
        _gameController.OnResultShow += ShowResult;
    }

    public void FinishLevel()
    {
        _gameController.OnResultShow -= ShowResult;
        Destroy(_currentLevel.gameObject);
        ShowMenu();
        
    }
    
    private void ShowMenu()
    {

        _currentLevel = MakeStartScene();

        if (_currentLevel != null)
        {
            _gameController.InitLevel(_currentLevel);
        }
        
        _uiController.OpenUI(UIState.Menu);
    }
    
    private void ShowResult()
    {
        _uiController.OpenUI(UIState.Result);
    }

    private LevelData MakeStartScene()
    {
        LevelData levelPrefab = _levelProvider.GetLevel();

        if (levelPrefab != null)
        {
            LevelData level = Instantiate(levelPrefab);
            return level;
        }
        else
        {
            Debug.Log("[Error]No level available");
            return null;
        }
    }
    
    

    //TODO Make the special class for that
    private IStoreData GetStoreData()
    {
        string json = PlayerPrefs.GetString("GAME_DATA");
        IStoreData storeData = JsonUtility.FromJson<StoreDataPrefs>(json);
        if (storeData == null)
            storeData = new StoreDataPrefs();
        storeData.Init(
            () =>
            {
                string jsn = JsonUtility.ToJson(storeData);
                PlayerPrefs.SetString("GAME_DATA",jsn);
            });
        return storeData;
    }
}
