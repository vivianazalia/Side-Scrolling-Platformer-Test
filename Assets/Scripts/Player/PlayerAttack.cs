using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private InputHandler _inputHandler;
    [SerializeField]
    private GameObject _attackArea;

    private void OnEnable()
    {
        _inputHandler.AttackEvent += Attack;
    }

    private void OnDisable()
    {
        _inputHandler.AttackEvent -= Attack;
    }

    private void Start()
    {
        _inputHandler.GameplayInputEnable();
    }

    private void Attack()
    {
        StartCoroutine(DelayAttackAreaActive());
    }

    private IEnumerator DelayAttackAreaActive()
    {
        _attackArea.SetActive(true);
        yield return new WaitForSeconds(.25f);
        _attackArea.SetActive(false);
    }
}
