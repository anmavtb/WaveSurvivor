using UnityEngine;

public class PlayerMagnet : MonoBehaviour
{
    [SerializeField] float magnetRadius = 3f;
    [SerializeField] float magnetForce = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GrabNearbyDrops();
    }

    private void PullDrop(Transform _target)
    {
        _target.position = Vector2.MoveTowards(_target.position, transform.position, magnetForce * Time.deltaTime);
    }

    private void GrabNearbyDrops()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, magnetRadius);
        foreach (Collider2D _hit in colliders)
        {
            if(_hit.CompareTag("Drop"))
            {
                PullDrop(_hit.transform);
            }
        }
    }

    private void GrabAllDrops()
    {
        if (DropManager.Instance.dropList.Count == 0) return;
        foreach (GameObject _drop in DropManager.Instance.dropList)
        {
            PullDrop(_drop.transform);
        }
    }

    private void OnDrawGizmosSelected()
    {
        AnmaGizmos.DrawSphere(transform.position, magnetRadius, Color.green);
    }
}