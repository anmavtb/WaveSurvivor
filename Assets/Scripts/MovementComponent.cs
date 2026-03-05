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

    private void Move()
    {
        Vector2 _movementValue = InputManager.Instance.Move.ReadValue<Vector2>();
        transform.position += transform.up * _movementValue.y * Time.deltaTime * (5 + (StatsManager.Instance.Speed / 100));
        transform.position += transform.right * _movementValue.x * Time.deltaTime * (5 + (StatsManager.Instance.Speed / 100));
    }
}