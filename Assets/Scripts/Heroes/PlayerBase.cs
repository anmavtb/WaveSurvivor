using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(MovementComponent))]
[RequireComponent(typeof(AttackComponent))]
[RequireComponent(typeof(StatsManager))]
[RequireComponent(typeof(PlayerExp))]

public class PlayerBase : Singleton<PlayerBase>
{
    [SerializeField] float expGrabDist = 2f;
    [SerializeField] float expGrabSpeed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GrabExpDrops();
    }

    private void GrabExpDrops()
    {
        if (ExpDropManager.Instance.expDrops.Count == 0) return;
        foreach (GameObject _drop in ExpDropManager.Instance.expDrops)
        {
            ExpDrop _expDrop = _drop.GetComponent<ExpDrop>();
            float dist = Vector2.Distance(transform.position, _expDrop.transform.position);
            if (dist <= expGrabDist)
            {
                _expDrop.MoveTowards(transform.position, expGrabSpeed);
            }
        }
    }

    private void GrabAllExp()
    {
        if (ExpDropManager.Instance.expDrops.Count == 0) return;
        foreach (GameObject _drop in ExpDropManager.Instance.expDrops)
        {
            ExpDrop _expDrop = _drop.GetComponent<ExpDrop>();
            _expDrop.MoveTowards(transform.position, expGrabSpeed);
        }
    }
}