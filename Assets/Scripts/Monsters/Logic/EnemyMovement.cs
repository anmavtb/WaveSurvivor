using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    protected EnemyBase enemyBase;
    protected SpriteRenderer spriteRenderer;

    protected void Awake()
    {
        enemyBase = GetComponent<EnemyBase>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Behaviour()
    {
        if (enemyBase.Target == null) return;
        Move();
    }

    protected void Move()
    {
        Rotate();
        Vector2 direction = (enemyBase.Target.position - transform.position).normalized;
        transform.Translate(direction * enemyBase.Speed * Time.deltaTime);
    }

    private void Rotate()
    {
        spriteRenderer.flipX = (enemyBase.Target.position.x > transform.position.x) ? false : true;
    }
}