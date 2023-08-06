using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class ResultUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _resultPanel;
    [SerializeField]
    private Button _resetButton;
    [SerializeField]
    private Button _mainMenuButton;
    [SerializeField]
    private TMP_Text _scoreText;

    public static UnityAction ShowResultEvent;

    private void OnEnable()
    {
        ShowResultEvent += ShowResult;
    }

    private void OnDisable()
    {
        ShowResultEvent -= ShowResult;
    }

    private void Awake()
    {
        SetButtonListener();
    }

    private void SetButtonListener()
    {
        _resetButton.onClick.RemoveAllListeners();
        _resetButton.onClick.AddListener(delegate { ResetGame(); });
        _mainMenuButton.onClick.RemoveAllListeners();
        _mainMenuButton.onClick.AddListener(delegate { GoToMainMenu(); });
    }

    private void ResetGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    private void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    private void ShowResult()
    {
        _scoreText.SetText("Score: " + DataController.Instance.GameData._data.Score.ToString());
        _resultPanel.SetActive(true);
    }
}
