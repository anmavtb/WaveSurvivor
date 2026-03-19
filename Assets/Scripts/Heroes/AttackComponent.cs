using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    [SerializeField] private float attackSpeed = 1f;
    [SerializeField] private float range = 1f;

    [SerializeField] private float attackCooldown = 0f;
    [SerializeField] private float attackRate = 1f;

    [SerializeField] private bool canAttack = false;

    [SerializeField] private GameObject bulletPrefab = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackSpeed = 1 + (StatsManager.Instance.PlayerAttackSpeed / 100);
        //range = 1 + (StatsManager.Instance.PlayerRange / 100);
    }

    // Update is called once per frame
    void Update()
    {
        if (canAttack) AttackTimer();
    }

    private void Attack()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().direction = new Vector2(1, 0);
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
}