using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameplayUI.SetScoreGameFinishEvent?.Invoke();
            ResultUI.ShowResultEvent?.Invoke();
        }
    }
}
