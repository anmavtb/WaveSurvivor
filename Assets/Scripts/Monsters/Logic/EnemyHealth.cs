using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    protected EnemyBase enemyBase;
    protected int currentHealth;

    [SerializeField] protected ExpDrop expDrop;

    protected void Awake()
    {
        enemyBase = GetComponent<EnemyBase>();
        currentHealth = enemyBase.Health;
    }

    public void TakeDamage(float _damages, Vector2 _hitDirection)
    {
        currentHealth -= (int)_damages;
        if (currentHealth <= 0) KillEnemy();
        Recoil(_hitDirection);
    }

    protected void Recoil(Vector2 _hitDirection)
    {
        transform.position += (Vector3)_hitDirection.normalized * 0.5f;
    }

    protected void DropExp()
    {
        ExpDrop _drop = Instantiate(expDrop, transform.position, Quaternion.identity);
        DropManager.Instance.AddDropToList(_drop.gameObject);
    }

    protected void KillEnemy()
    {
        GlobalStatsManager.Instance.AddKill();
        DropExp();
        enemyBase.DestroyEnemy();
    }
}