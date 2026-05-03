using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(EnemyHealth))]

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] protected int health = 2;
    [SerializeField] protected float speed = 2f;

    protected Transform target = null;
    protected EnemyMovement enemyMovement;
    protected EnemyHealth enemyHealth;

    public int Health => health;
    public float Speed => speed;
    public Transform Target => target;

    protected void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected void Start()
    {
        target = StatsManager.Instance.GetComponent<Transform>();
    }

    // Update is called once per frame
    protected void Update()
    {
        if (target != null)
        {
            enemyMovement.Behaviour();
        }
    }

    public void DestroyEnemy() { Destroy(gameObject); }

    protected void OnTriggerEnter2D(Collider2D _collision)
    {
        if (_collision.CompareTag("Player"))
        {
            //Enemy hits player
        }
    }
}