using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float weaponSpeed = 1f;

    [SerializeField] public GameObject target = null;
    [SerializeField] public Vector2 direction;

    [SerializeField] private float lifeTime = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        MoveWeapon();
    }

    public void SetTarget(GameObject _enemy)
    {
        if (_enemy == null) return;
        direction = (_enemy.transform.position - transform.position).normalized;
    }

    private void MoveWeapon()
    {
        transform.Translate(direction * weaponSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if (_collision.CompareTag("Enemy"))
        {

            float _damages = 1 + (1 * (StatsManager.Instance.Damages.Value / 100));
            EnemyHealth enemy = _collision.gameObject.GetComponent<EnemyHealth>();
            enemy.TakeDamage(_damages, direction);
            Destroy(gameObject);
        }
    }
}