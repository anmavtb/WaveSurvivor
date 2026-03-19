using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    [SerializeField] private Vector2 destination = Vector2.zero;
    [SerializeField] private float speed = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = StatsManager.Instance.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Behaviour();
    }

    private void Behaviour()
    {
        UpdateDestination();
        Move();
    }

    private void UpdateDestination()
    {
        destination = target.position;
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        //transform.LookAt(target);
    }
}