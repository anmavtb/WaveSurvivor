using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class AttackComponent : MonoBehaviour
{
    [SerializeField] private float attackSpeed = 1f;
    [SerializeField] private float range = 1f;

    [SerializeField] private float attackCooldown = 0f;
    [SerializeField] private float attackRate = 1f;

    [SerializeField] private GameObject nearestEnemy;

    [SerializeField] private GameObject bulletPrefab = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateStats();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStats();
        nearestEnemy = GetNearestEnemy();
        if (nearestEnemy == null) return;
        AttackTimer();
    }

    private void UpdateStats()
    {
        attackSpeed = 1 + (StatsManager.Instance.AttackSpeed.Value / 100);
        range = 5 + (StatsManager.Instance.Range.Value / 10);
    }

    private void Attack()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetTarget(nearestEnemy);
    }

    private void AttackTimer()
    {
        attackCooldown += Time.deltaTime;
        attackRate = 1 / attackSpeed;
        if (attackRate < 0) attackRate = 0.01f;
        if (attackCooldown >= attackRate)
        {
            attackCooldown = 0;
            Attack();
        }
    }

    private GameObject GetNearestEnemy()
    {
        List<GameObject> enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        float minDist = range;
        foreach (GameObject enemy in enemies)
        {
            float dist = Vector2.Distance(transform.position, enemy.transform.position);
            if (dist <= minDist)
            {
                minDist = dist;
                nearestEnemy = enemy;
                return nearestEnemy;
            }
        }
        return null;
    }

    private void OnDrawGizmosSelected()
    {
        AnmaGizmos.DrawSphere(transform.position, range, Color.red);
    }

    private void OnDrawGizmos()
    {
        if (GetNearestEnemy() == null) return;
        AnmaGizmos.DrawSphere(nearestEnemy.transform.position, 1, Color.red);
    }
}