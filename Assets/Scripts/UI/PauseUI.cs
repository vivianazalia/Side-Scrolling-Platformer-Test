using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    [SerializeField]
    private InputHandler _inputHandler;
    [SerializeField]
    private GameObject _pausePanel;
    [SerializeField]
    private Button _resumeButton;
    [SerializeField]
    private Button _resetButton;
    [SerializeField]
    private Button _mainMenuButton;

    private void OnEnable()
    {
        _inputHandler.PauseGame += Pause;
    }

    private void OnDisable()
    {
        _inputHandler.PauseGame -= Pause;
    }

    private void Awake()
    {
        SetButtonListener();
    }

    private void SetButtonListener()
    {
        _resumeButton.onClick.RemoveAllListeners();
        _resumeButton.onClick.AddListener(delegate { Resume(); });
        _resetButton.onClick.RemoveAllListeners();
        _resetButton.onClick.AddListener(delegate { ResetGame(); });
        _mainMenuButton.onClick.RemoveAllListeners();
        _mainMenuButton.onClick.AddListener(delegate { GoToMainMenu(); });
    }

    private void ResetGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    private void Resume()
    {
        _pausePanel.SetActive(false);
        _inputHandler.GameplayInputEnable();
    }

    private void Pause()
    {
        Debug.Log("Pause");
        _pausePanel.SetActive(true);
    }

    private void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
