using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class ExpDrop : MonoBehaviour
{
    [SerializeField] private int expValue;
    [SerializeField] private Rigidbody2D rb;

    public int ExpValue => expValue;

    public void MoveTowards(Vector2 _target, float _speed)
    {
        Vector2 direction = (_target-(Vector2)transform.position).normalized;
        rb.linearVelocity = direction * _speed;
    }

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if (_collision.CompareTag("Player"))
        {
            _collision.GetComponent<PlayerExp>().AddExp(expValue);
            ExpDropManager.Instance.RemoveExpToList(this.gameObject);
        }
    }
}