using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameplayUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreText;
    [SerializeField]
    private TMP_Text _highScoreText;

    private int _score;
    private int _highscore;

    public static UnityAction<int> AddScoreEvent;
    public static UnityAction SetScoreGameFinishEvent;
    public static UnityAction<int> LoadHighscoreEvent;

    public int Score { get => _score; }

    private void OnEnable()
    {
        AddScoreEvent += AddScore;
        SetScoreGameFinishEvent += SetDataScore;
        LoadHighscoreEvent += LoadHighScore;
    }

    private void OnDisable()
    {
        AddScoreEvent -= AddScore;
        SetScoreGameFinishEvent -= SetDataScore;
        LoadHighscoreEvent -= LoadHighScore;
    }

    private void LoadHighScore(int highscore)
    {
        _highscore = highscore;
        _highScoreText.SetText("Highscore: " + _highscore.ToString());
    }

    private void AddScore(int score)
    {
        _score += score;
        _scoreText.SetText("Score: " + _score.ToString());
    }

    private void SetDataScore()
    {
        if(_score > _highscore)
        {
            _highscore = _score;
        }

        DataController.SetDataEvent?.Invoke(_score, _highscore);
    }
}
