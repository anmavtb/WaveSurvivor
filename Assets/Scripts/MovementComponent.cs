using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    //Rigidbody rigidBody = null;

    // Start is called before the first frame update
    void Start()
    {
        //rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 _movementValue = InputManager.Instance.Move.ReadValue<Vector2>();
        transform.position += transform.up * _movementValue.y * Time.deltaTime * StatsManager.Instance.Speed;
        transform.position += transform.right * _movementValue.x * Time.deltaTime * StatsManager.Instance.Speed;
    }
}