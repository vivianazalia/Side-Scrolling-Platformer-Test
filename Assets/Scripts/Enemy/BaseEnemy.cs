using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    public abstract void Move();
    public abstract void Attack();
    public virtual void Hit()
    {
        gameObject.SetActive(false);
        GameplayUI.AddScoreEvent?.Invoke(10);
    }
}
