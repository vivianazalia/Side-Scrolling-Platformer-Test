using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataController : MonoBehaviour
{
    [SerializeField]
    private ScoreScriptableObject _scoreSO;

    public static DataController Instance = null;

    public static UnityAction<int, int> SetDataEvent;
    public ScoreScriptableObject GameData { get => _scoreSO; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void OnEnable()
    {
        SetDataEvent += SetData;
    }

    private void OnDisable()
    {
        SetDataEvent -= SetData;
    }

    private void Start()
    {
        GameplayUI.LoadHighscoreEvent?.Invoke(_scoreSO._data.Highscore);
    }

    private void SetData(int score, int highscore)
    {
        _scoreSO._data.Score = score;
        _scoreSO._data.Highscore = highscore;
    }
}

[System.Serializable]
public struct Data
{
    public int Score;
    public int Highscore;
}
