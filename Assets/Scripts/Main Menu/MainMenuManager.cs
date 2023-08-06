using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private InputHandler _inputHandler;

    private void OnEnable()
    {
        _inputHandler.StartGameEvent += StartGame;
        _inputHandler.QuitGameEvent += QuitGame;
    }

    private void OnDisable()
    {
        _inputHandler.StartGameEvent -= StartGame;
        _inputHandler.QuitGameEvent -= QuitGame;
    }

    private void Start()
    {
        _inputHandler.MainMenuInputEnable();
    }

    private void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
