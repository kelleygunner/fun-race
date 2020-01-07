using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    [SerializeField] private GameObject menuUi;
    [SerializeField] private GameObject gameUi;
    [SerializeField] private GameObject resultUi;

    public void OpenUI(UIState state)
    {
        switch (state)
        {
            case UIState.Menu:
                menuUi.SetActive(true);
                gameUi.SetActive(false);
                resultUi.SetActive(false);
                break;
            case UIState.Game:
                menuUi.SetActive(false);
                gameUi.SetActive(true);
                resultUi.SetActive(false);
                break;
            case UIState.Result:
                menuUi.SetActive(false);
                gameUi.SetActive(false);
                resultUi.SetActive(true);
                break;
        }
    }
    
}

public enum UIState
{
    Menu,
    Game,
    Result
}