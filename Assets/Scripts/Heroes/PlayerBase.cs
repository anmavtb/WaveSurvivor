using System.Collections.Generic;
using System.Linq;
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
    List<GameObject> expDrops;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetExpDropsOnMap();
        GrabExpDrops();
    }

    private List<GameObject> GetExpDropsOnMap()
    {
        expDrops = GameObject.FindGameObjectsWithTag("ExpDrop").ToList();
        return expDrops;
    }

    private void GrabExpDrops()
    {
        if (expDrops == null) return;
        float _expGrabDist = 2f;
        foreach (GameObject expDrop in expDrops)
        {
            float dist = Vector2.Distance(transform.position, expDrop.transform.position);
            if (dist <= _expGrabDist)
            {
                PlayerExp.Instance.AddExp(1);
                Destroy(expDrop);
            }
        }
    }

    private void GrabAllExp()
    {
        if (expDrops == null) return;
        PlayerExp.Instance.AddExp(expDrops.Count);
        foreach (GameObject expDrop in expDrops) Destroy(expDrop);
    }
}