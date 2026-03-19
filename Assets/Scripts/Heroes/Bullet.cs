using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float weaponSpeed = 1f;

    [SerializeField] public Vector2 direction;

    [SerializeField] private float lifeTime = 10f;

    //public Vector2 Direction = direction;

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

    private void MoveWeapon()
    {
        transform.Translate(direction * weaponSpeed * Time.deltaTime);
    }
}
