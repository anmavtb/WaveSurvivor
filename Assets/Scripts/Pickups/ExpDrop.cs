using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class ExpDrop : MonoBehaviour
{
    [SerializeField] private int expValue;
    [SerializeField] private Rigidbody2D rb;

    public int ExpValue => expValue;

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if (_collision.CompareTag("Player"))
        {
            _collision.GetComponent<PlayerExp>().AddExp(expValue);
            DropManager.Instance.RemoveDropToList(this.gameObject);
        }
    }
}