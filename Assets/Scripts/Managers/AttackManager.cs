using System;
using UnityEngine;

public class AttackManager : Singleton<AttackManager>
{
    [SerializeField] private float currentAttackSpeed = 1f;
    [SerializeField] private float gameTime = 0f;
    [SerializeField] private bool canAttack = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        currentAttackSpeed = 1 + (StatsManager.Instance.AttackSpeed / 100);
        if (canAttack && AttackTimer())
        {
            Debug.Log("Attack !");
        }
    }

    private bool AttackTimer()
    {
        gameTime += Time.deltaTime;
        float _attackRate = 1 / currentAttackSpeed;
        if (_attackRate < 0) _attackRate = 0f;
        if (gameTime >= _attackRate)
        {
            gameTime = 0;
            return true;
        }
        return false;
    }
}